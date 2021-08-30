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
    public partial class KeyboardMods : Form
    {
        public KeyboardMods()
        {
            InitializeComponent();
            listBox.Items.Clear();
            foreach (KeyboardHook.MOD value in Enum.GetValues(typeof(KeyboardHook.MOD)))
                listBox.Items.Add(value);
        }
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyboardHook.MOD mod = (KeyboardHook.MOD)listBox.SelectedItem;
            KeyboardHook.keyboardMod = mod;
            applyButton.Enabled = true;
        }
        private void applyButton_Click(object sender, EventArgs e)
        {
            KeyboardHook.useKeyboardMod = true;
            applyButton.Enabled = false;
        }
        private void KeyboardMods_FormClosing(object sender, FormClosingEventArgs e)
        {
            KeyboardHook.useKeyboardMod = false;
        }
    }
}
