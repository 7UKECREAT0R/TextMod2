using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextMod_2.Core;

namespace TextMod_2.Forms
{
    public partial class EncryptorDecryptor : Form
    {
        public enum EncryptionType
        {
            Base64,
            TextModEncryption,
            SeedShift
        }

        public EncryptorDecryptor()
        {
            InitializeComponent();
        }
        private void EncryptorDecryptor_Load(object sender, EventArgs e)
        {
            encryptionTypeBox.Items.Add(EncryptionType.Base64);
            encryptionTypeBox.Items.Add(EncryptionType.TextModEncryption);
            encryptionTypeBox.Items.Add(EncryptionType.SeedShift);
            encryptionTypeBox.SelectedIndex = 1;
        }
        private void encryptionTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SelectedType == EncryptionType.SeedShift)
            {
                Height = 559;
            } else
            {
                Height = 528;
            }
        }
        public EncryptionType SelectedType
        {
            get
            {
                return (EncryptionType)encryptionTypeBox.SelectedItem;
            }
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            EncryptionType type = SelectedType;
            string input = topBox.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("You need to put in some text to encrypt. [Top Box]", "TextMod");
                return;
            }

            string encrypted;
            switch(type)
            {
                case EncryptionType.Base64:
                    encrypted = EncryptorBase.EncryptBase64(input);
                    break;
                case EncryptionType.TextModEncryption:
                    encrypted = EncryptorBase.EncryptTextMod(input);
                    break;
                case EncryptionType.SeedShift:
                    encrypted = EncryptorBase.EncryptSeedShift(input, seedTextBox.Text);
                    break;
                default:
                    encrypted = input;
                    break;
            }

            bottomBox.Text = encrypted;
        }
        private void decryptButton_Click(object sender, EventArgs e)
        {
            EncryptionType type = SelectedType;
            string input = bottomBox.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("You need to put in some text to decrypt. [Bottom Box]", "TextMod");
                return;
            }

            string decrypted;
            switch (type)
            {
                case EncryptionType.Base64:
                    decrypted = EncryptorBase.DecryptBase64(input);
                    break;
                case EncryptionType.TextModEncryption:
                    decrypted = EncryptorBase.DecryptTextMod(input);
                    break;
                case EncryptionType.SeedShift:
                    decrypted = EncryptorBase.DecryptSeedShift(input, seedTextBox.Text);
                    break;
                default:
                    decrypted = input;
                    break;
            }

            topBox.Text = decrypted;
        }
    }
}
