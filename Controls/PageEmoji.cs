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
using TextMod_2.Core;

namespace TextMod_2.Controls
{
    public partial class PageEmoji : UserControl
    {
        public int selectedIndex = -1;

        public void BuildDisplay()
        {
            Emoji[] emojis = TextModCore.emoji.GetAllEmoji();
            string[] lines = emojis.Select(e => "\"" + e.name + "\", " + e.path).ToArray();
            display.Items.Clear();
            foreach (string line in lines)
                display.Items.Add(line);
        }
        public PageEmoji()
        {
            InitializeComponent();
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            string[] files = openFileDialog.FileNames;
            TextModCore.emoji.CreateEmoji(files);
            selectedIndex = -1;
            removeButton.Enabled = false;
            renameTextBox.Enabled = false;
            deselectButton.Enabled = false;
            renameTextBox.Text = "";
            emojiPreview.BackgroundImage?.Dispose();
            emojiPreview.BackgroundImage = null;
            BuildDisplay();
        }
        private void removeButton_Click(object sender, EventArgs e)
        {
            if (selectedIndex == -1)
            {
                MessageBox.Show("Select an emoji to remove on the left panel.", "TextMod");
                return;
            }
            TextModCore.emoji.RemoveEmojiAtIndex(selectedIndex);
            selectedIndex = -1;
            removeButton.Enabled = false;
            renameTextBox.Enabled = false;
            deselectButton.Enabled = false;
            renameTextBox.Text = "";
            emojiPreview.BackgroundImage?.Dispose();
            emojiPreview.BackgroundImage = null;
            BuildDisplay();
        }
        private void display_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = display.SelectedIndex;
            removeButton.Enabled = true;
            renameTextBox.Enabled = true;
            deselectButton.Enabled = true;
            if (TextModCore.emoji.TryGetEmojiByIndex(selectedIndex, out Emoji? clicked))
            {
                renameTextBox.Text = clicked.Value.name;
                emojiPreview.BackgroundImage?.Dispose();
                emojiPreview.BackgroundImage = null;
                if (!File.Exists(clicked.Value.path))
                {
                    TextModCore.emoji.RemoveEmojiAtIndex(selectedIndex);
                    selectedIndex = -1;
                    removeButton.Enabled = false;
                    renameTextBox.Enabled = false;
                    deselectButton.Enabled = false;
                    renameTextBox.Text = "";
                    BuildDisplay();
                    MessageBox.Show("Image no longer exists. Automatically removed.");
                    return;
                }
                emojiPreview.BackgroundImage = TextModCore.emoji.GetEmojiImage(clicked.Value);
            }
        }
        private void renameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (selectedIndex == -1)
            {
                // if this code runs theres a problem
                removeButton.Enabled = false;
                renameTextBox.Enabled = false;
                deselectButton.Enabled = false;
                emojiPreview.BackgroundImage?.Dispose();
                emojiPreview.BackgroundImage = null;
                return;
            }
            if (string.IsNullOrWhiteSpace(renameTextBox.Text))
                return;
            if (TextModCore.emoji.TryGetEmojiByIndex(selectedIndex, out Emoji? _selected))
            {
                Emoji selected = _selected.Value;
                string change = Emoji.FilterCharacters(renameTextBox.Text);
                if(!change.Equals(renameTextBox.Text))
                {
                    int selStart = renameTextBox.SelectionStart;
                    renameTextBox.Text = change;
                    renameTextBox.SelectionStart = selStart;
                }
                selected.name = renameTextBox.Text;
                TextModCore.emoji.ModifyEmojiAtIndex(selectedIndex, selected);
                display.Items[selectedIndex] = "\"" + selected.name + "\", " + selected.path;
            } else
            {
                MessageBox.Show("something went wrong... try restarting textmod?");
            }
        }
        private void deselectButton_Click(object sender, EventArgs e)
        {
            display.ClearSelected();
            selectedIndex = -1;
            removeButton.Enabled = false;
            renameTextBox.Enabled = false;
            deselectButton.Enabled = false;
            renameTextBox.Text = "";
            emojiPreview.BackgroundImage?.Dispose();
            emojiPreview.BackgroundImage = null;
        }
    }
}
