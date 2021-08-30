using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextMod_2.Controls;

namespace TextMod_2.Forms.Art
{
    public partial class AsciiArtEmoji : Form
    {
        public AsciiArtEmoji()
        {
            InitializeComponent();
            brushType.Items.Clear();
            foreach (var bt in Enum.GetValues(typeof(EmojiCell)))
                brushType.Items.Add(bt);
            brushType.SelectedItem = EmojiCell.BLACK;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            emojiGrid.Clear();
        }
        private void copyButton_Click(object sender, EventArgs e)
        {
            string msg = emojiGrid.GetString();
            Clipboard.SetText(msg);
        }

        private void brushType_SelectedIndexChanged(object sender, EventArgs e)
        {
            emojiGrid.SetTool((EmojiCell)brushType.SelectedItem);
        }
    }
}
