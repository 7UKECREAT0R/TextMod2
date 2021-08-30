using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextMod_2.Forms
{
    public partial class ZipFileHider : Form
    {
        string zipPath;
        ZIPFile file;

        public ZipFileHider()
        {
            InitializeComponent();
        }

        private void chooseZip_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            zipPath = openFileDialog.FileName;
            file = new ZIPFile(zipPath);
            PopulateListBox();
            displayBox.Text = zipPath;
        }
        private void PopulateListBox()
        {
            filesInside.Items.Clear();
            filesInside.Items.AddRange(file.files);
            hideButton.Enabled = false;
            searchButton.Enabled = true;
            restoreAllFilesButton.Enabled = false;
            hiddenFilesDisplay.Items.Clear();
            return;
        }

        private void chooseZip_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length < 1)
                return;
            string fileName = files[0];
            string ext = Path.GetExtension(fileName);
            if (!ext.ToLower().Equals("zip"))
            {
                MessageBox.Show("Only ZIP files are accepted.");
                return;
            }
            zipPath = fileName;
            file = new ZIPFile(zipPath);
            PopulateListBox();
            displayBox.Text = zipPath;
        }
        private void chooseZip_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void filesInside_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filesInside.SelectedIndex < 0)
            {
                hideButton.Enabled = false;
                searchButton.Enabled = false;
                restoreAllFilesButton.Enabled = false;
                hiddenFilesDisplay.Items.Clear();
                return;
            }
            hideButton.Enabled = true;
        }
        private void hiddenFilesDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filesInside.SelectedIndex < 0)
            {
                restoreAllFilesButton.Enabled = false;
                hiddenFilesDisplay.Items.Clear();
                return;
            }
            restoreAllFilesButton.Enabled = true;
        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            object selected = filesInside.SelectedItem;

            if (selected == null)
            {
                MessageBox.Show("No item selected.");
                return;
            }

            int index = filesInside.SelectedIndex;
            var list = file.files.ToList();
            list.RemoveAt(index);
            file.files = list.ToArray();
            file.WriteToFile(zipPath);
            PopulateListBox();
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            var localFiles = file.actualFiles;
            var centralDirectory = file.files;

            List<ZIPLocalFile> _missing = new List<ZIPLocalFile>();
            foreach(ZIPLocalFile file in localFiles)
            {
                // Search for in the central directory.
                // If the file is missing, then it's hidden.
                bool present = false;
                foreach(ZIPCentralDirectoryEntry entry in centralDirectory)
                {
                    if(entry.crc32 == file.crc32)
                    {
                        present = true;
                        break;
                    }
                }

                if (!present)
                    _missing.Add(file);
            }

            ZIPLocalFile[] missing = _missing.ToArray();
            if(missing.Length < 1)
            {
                MessageBox.Show("No hidden files could be found.");
                return;
            }

            hiddenFilesDisplay.Items.Clear();
            hiddenFilesDisplay.Items.AddRange(missing);
            restoreAllFilesButton.Enabled = false;
            searchButton.Enabled = false;
        }
        private void restoreAllFilesButton_Click(object sender, EventArgs e)
        {
            var localFiles = file.actualFiles;
            var centralDirectory = file.files.ToList();

            int index = -1;
            foreach (ZIPLocalFile file in localFiles)
            {
                index++;

                // Search for in the central directory.
                // If the file is missing, then it's hidden.
                bool present = false;
                foreach (ZIPCentralDirectoryEntry entry in centralDirectory)
                {
                    if (entry.crc32 == file.crc32)
                    {
                        present = true;
                        break;
                    }
                }

                if (!present)
                {
                    ZIPCentralDirectoryEntry cde = ZIPCentralDirectoryEntry.Fabricate(file);
                    centralDirectory.Insert(index, cde);
                }
            }

            file.files = centralDirectory.ToArray();
            file.WriteToFile(zipPath);
            PopulateListBox();
        }
    }
    public class ZIPFile
    {
        public ZIPLocalFile[] actualFiles;
        public ZIPCentralDirectoryEntry[] files;
        public ZIPCentralDirectoryEnd ending;

        public ZIPFile(string filePath)
        {
            try
            {
                using (FileStream stream = File.OpenRead(filePath))
                using (BinaryReader reader = new BinaryReader(stream, Encoding.UTF32))
                {
                    ZIPSignature header;
                    List<ZIPLocalFile> smallFiles = new List<ZIPLocalFile>();
                    List<ZIPCentralDirectoryEntry> cdrEntries = new List<ZIPCentralDirectoryEntry>();
                    while ((header = (ZIPSignature)reader.ReadInt32()) == ZIPSignature.LocalFileEntry)
                        smallFiles.Add(new ZIPLocalFile(reader));
                    reader.BaseStream.Position -= 4;
                    while ((header = (ZIPSignature)reader.ReadInt32()) == ZIPSignature.CDREntry)
                        cdrEntries.Add(new ZIPCentralDirectoryEntry(reader));
                    actualFiles = smallFiles.ToArray();
                    files = cdrEntries.ToArray();
                    ending = new ZIPCentralDirectoryEnd(reader);
                    reader.Close();
                }
            } catch(Exception e)
            {
                MessageBox.Show("ZIP file read error.\n" + e.Message + "\n" + e.ToString());
            }
        }
        public void WriteToFile(string filePath)
        {
            try
            {
                using (FileStream stream = File.OpenWrite(filePath))
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    foreach (ZIPLocalFile localFile in actualFiles)
                        localFile.Write(writer);
                    foreach (ZIPCentralDirectoryEntry cde in files)
                        cde.Write(writer);
                    ending.centralDirectoryCountTotal = (short)files.Length;
                    ending.centralDirectoryCountOnDisk = (short)files.Length;
                    ending.Write(writer);
                    writer.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ZIP file write error.\n" + e.Message + "\n" + e.ToString());
            }
        }
    }
    public enum ZIPSignature : int
    {
        LocalFileEntry = 0x04034b50,
        CDREntry = 0x02014b50,
        EndOfCDR = 0x06054b50,
        EOF = -1
    }
    public class ZIPLocalFile
    {
        public int headerSignature; // ZIPSignature.LocalFileEntry
        public short minVersion;
        public short bitFlag;
        public short compressionMethod;
        public short lastModificationTime;
        public short lastModificationDate;
        public int crc32;
        public int compressedSize;
        public int uncompressedSize;
        public short fileNameLength;
        public short extraFieldLength;

        public string fileName; // fileNameLength
        public byte[] extraField; // extraFieldLength

        public byte[] compressedContents; // not in header inherently

        public ZIPLocalFile(BinaryReader bytes)
        {
            headerSignature = (int)ZIPSignature.LocalFileEntry;
            minVersion = bytes.ReadInt16();
            bitFlag = bytes.ReadInt16();
            compressionMethod = bytes.ReadInt16();
            lastModificationTime = bytes.ReadInt16();
            lastModificationDate = bytes.ReadInt16();
            crc32 = bytes.ReadInt32();
            compressedSize = bytes.ReadInt32();
            uncompressedSize = bytes.ReadInt32();
            fileNameLength = bytes.ReadInt16();
            extraFieldLength = bytes.ReadInt16();

            // dynamic
            fileName = Encoding.ASCII.GetString(bytes.ReadBytes(fileNameLength));
            extraField = bytes.ReadBytes(extraFieldLength);
            compressedContents = bytes.ReadBytes(compressedSize);
        }
        public void Write(BinaryWriter writer)
        {
            writer.Write(headerSignature);
            writer.Write(minVersion);
            writer.Write(bitFlag);
            writer.Write(compressionMethod);
            writer.Write(lastModificationTime);
            writer.Write(lastModificationDate);
            writer.Write(crc32);
            writer.Write(compressedSize);
            writer.Write(uncompressedSize);
            byte[] fileNameBytes = Encoding.ASCII.GetBytes(fileName);
            writer.Write(fileNameBytes.Length);
            writer.Write(extraField.Length);
            writer.Write(fileNameBytes);
            writer.Write(extraField);
            writer.Write(compressedContents);
        }

        public override string ToString()
        {
            return "LocalFileEntry: " + fileName + " - " + compressedSize + " bytes";
        }
    }
    public class ZIPCentralDirectoryEntry
    {
        public int headerSignature; // ZIPSignature.CDREntry
        public short versionMadeBy;
        public short versionToExtract;
        public short bitFlag;
        public short compressionMethod;
        public short lastModificationTime;
        public short lastModificationDate;
        public int crc32;
        public int compressedSize;
        public int uncompressedSize;
        public short fileNameLength;
        public short extraFieldLength;
        public short fileCommentLength;
        public short startDiskNumber;
        public short internalFileAttrib;
        public int externalFileAttrib;
        public int localFileHeaderOffset;

        public string fileName; // fileNameLength
        public byte[] extraField; // extraFieldLength
        public string fileComment; // fileCommentLength

        private ZIPCentralDirectoryEntry()
        {
            headerSignature = (int)ZIPSignature.CDREntry;
        }
        public ZIPCentralDirectoryEntry(BinaryReader bytes)
        {
            headerSignature = (int)ZIPSignature.CDREntry;
            versionMadeBy = bytes.ReadInt16();
            versionToExtract = bytes.ReadInt16();
            bitFlag = bytes.ReadInt16();
            compressionMethod = bytes.ReadInt16();
            lastModificationTime = bytes.ReadInt16();
            lastModificationDate = bytes.ReadInt16();
            crc32 = bytes.ReadInt32();
            compressedSize = bytes.ReadInt32();
            uncompressedSize = bytes.ReadInt32();
            fileNameLength = bytes.ReadInt16();
            extraFieldLength = bytes.ReadInt16();
            fileCommentLength = bytes.ReadInt16();
            startDiskNumber = bytes.ReadInt16();
            internalFileAttrib = bytes.ReadInt16();
            externalFileAttrib = bytes.ReadInt32();
            localFileHeaderOffset = bytes.ReadInt32();

            // dynamic
            fileName = Encoding.ASCII.GetString(bytes.ReadBytes(fileNameLength));
            extraField = bytes.ReadBytes(extraFieldLength);
            fileComment = Encoding.ASCII.GetString(bytes.ReadBytes(fileCommentLength));
        }
        public void Write(BinaryWriter writer)
        {
            writer.Write(headerSignature);
            writer.Write(versionMadeBy);
            writer.Write(versionToExtract);
            writer.Write(bitFlag);
            writer.Write(compressionMethod);
            writer.Write(lastModificationTime);
            writer.Write(lastModificationDate);
            writer.Write(crc32);
            writer.Write(compressedSize);
            writer.Write(uncompressedSize);
            byte[] fileNameBytes = Encoding.ASCII.GetBytes(fileName);
            byte[] fileCmntBytes = Encoding.ASCII.GetBytes(fileComment);
            writer.Write(fileNameBytes.Length);
            writer.Write(extraField.Length);
            writer.Write(fileCmntBytes.Length);
            writer.Write(startDiskNumber);
            writer.Write(internalFileAttrib);
            writer.Write(externalFileAttrib);
            writer.Write(localFileHeaderOffset);
            writer.Write(fileNameBytes);
            writer.Write(extraField);
            writer.Write(fileCmntBytes);
        }
        public static ZIPCentralDirectoryEntry Fabricate(ZIPLocalFile localFile)
        {
            ZIPCentralDirectoryEntry entry = new ZIPCentralDirectoryEntry();
            entry.versionMadeBy = 31;
            entry.versionToExtract = 20;
            entry.bitFlag = localFile.bitFlag;
            entry.compressionMethod = localFile.compressionMethod;
            entry.lastModificationTime = localFile.lastModificationTime;
            entry.lastModificationDate = localFile.lastModificationDate;
            entry.crc32 = localFile.crc32;
            entry.compressedSize = localFile.compressedSize;
            entry.uncompressedSize = localFile.uncompressedSize;
            entry.fileName = localFile.fileName;
            entry.extraField = localFile.extraField;
            entry.startDiskNumber = 0;
            entry.fileComment = "Restored with TextMod";
            entry.internalFileAttrib = 0;
            entry.externalFileAttrib = 32;
            entry.localFileHeaderOffset = 0;
            return entry;
        }

        public override string ToString()
        {
            return "CentralDirectoryEntry: " + fileName + " - " + compressedSize + " bytes";
        }
    }
    public class ZIPCentralDirectoryEnd
    {
        public int headerSignature; // ZIPSignature.EndOfCDR
        public short diskNumber;
        public short centralDirectoryDiskStart;
        public short centralDirectoryCountOnDisk;
        public short centralDirectoryCountTotal;
        public int centralDirectorySize;
        public int centralDirectoryOffset;
        public short commentLength;

        public string comment; // commentLength

        public ZIPCentralDirectoryEnd(BinaryReader bytes)
        {
            headerSignature = (int)ZIPSignature.EndOfCDR;
            diskNumber = bytes.ReadInt16();
            centralDirectoryDiskStart = bytes.ReadInt16();
            centralDirectoryCountOnDisk = bytes.ReadInt16();
            centralDirectoryCountTotal = bytes.ReadInt16();
            centralDirectorySize = bytes.ReadInt32();
            centralDirectoryOffset = bytes.ReadInt32();
            commentLength = bytes.ReadInt16();

            // dynamic
            comment = Encoding.ASCII.GetString(bytes.ReadBytes(commentLength));
        }
        public void Write(BinaryWriter writer)
        {
            writer.Write(headerSignature);
            writer.Write(diskNumber);
            writer.Write(centralDirectoryDiskStart);
            writer.Write(centralDirectoryCountOnDisk);
            writer.Write(centralDirectoryCountTotal);
            writer.Write(centralDirectorySize);
            writer.Write(centralDirectoryOffset);
            byte[] commentBytes = Encoding.ASCII.GetBytes(comment);
            writer.Write(commentBytes.Length);
            writer.Write(commentBytes);
        }
    }
}