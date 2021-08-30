using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextMod_2.Forms.Art;

namespace TextMod_2.Forms
{
    public partial class AsciiArt : Form
    {
        public AsciiArt()
        {
            InitializeComponent();
        }
        private void DisposeOnClose(object sender, FormClosedEventArgs e)
        {
            Form f = sender as Form;
            f.FormClosed -= DisposeOnClose;
            f.Dispose();
        }

        private void emojiButton_Click(object sender, EventArgs e)
        {
            AsciiArtEmoji emoji = new AsciiArtEmoji();
            emoji.FormClosed += DisposeOnClose;
            emoji.ShowDialog();
        }
        private void textButton_Click(object sender, EventArgs e)
        {
            AsciiArtText text = new AsciiArtText();
            text.FormClosed += DisposeOnClose;
            text.ShowDialog();
        }
        private void imageButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

        }
    }
}
