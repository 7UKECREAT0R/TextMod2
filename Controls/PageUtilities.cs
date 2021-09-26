using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextMod_2.Forms;

namespace TextMod_2.Controls
{
    public partial class PageUtilities : UserControl
    {
        Form openWindow = null;
        public PageUtilities()
        {
            InitializeComponent();
        }
        private void autocounterButton_Click(object sender, EventArgs e)
        {
            AutoCounter counterWindow = new AutoCounter();
            AnyFormClosed(null, null);
            counterWindow.FormClosed += AnyFormClosed;
            openWindow = counterWindow;
            counterWindow.Show();
        }
        private void encryptorButton_Click(object sender, EventArgs e)
        {
            EncryptorDecryptor encryptor = new EncryptorDecryptor();
            AnyFormClosed(null, null);
            encryptor.FormClosed += AnyFormClosed;
            openWindow = encryptor;
            encryptor.Show();
        }
        private void zipfileButton_Click(object sender, EventArgs e)
        {
            ZipFileHider zipFileHider = new ZipFileHider();
            AnyFormClosed(null, null);
            zipFileHider.FormClosed += AnyFormClosed;
            openWindow = zipFileHider;
            zipFileHider.Show();
        }
        private void asciiArtButton_Click(object sender, EventArgs e)
        {
            AsciiArt art = new AsciiArt();
            AnyFormClosed(null, null);
            art.FormClosed += AnyFormClosed;
            openWindow = art;
            art.Show();
        }
        private void keyboardModsButton_Click(object sender, EventArgs e)
        {
            KeyboardMods mods = new KeyboardMods();
            AnyFormClosed(null, null);
            mods.FormClosed += AnyFormClosed;
            openWindow = mods;
            mods.Show();
        }
        private void idDecoderButton_Click(object sender, EventArgs e)
        {
            IdDecoder decoder = new IdDecoder();
            AnyFormClosed(null, null);
            decoder.FormClosed += AnyFormClosed;
            openWindow = decoder;
            decoder.Show();
        }
        private void longTyperButton_Click(object sender, EventArgs e)
        {
            LongTyper decoder = new LongTyper((ParentForm as Form1).textMod);
            AnyFormClosed(null, null);
            decoder.FormClosed += AnyFormClosed;
            openWindow = decoder;
            decoder.Show();
        }

        private void AnyFormClosed(object sender, FormClosedEventArgs e)
        {
            if (openWindow != null)
            {
                openWindow.FormClosed -= AnyFormClosed;
                openWindow.Dispose();
                openWindow = null;
            }
        }
    }
}
