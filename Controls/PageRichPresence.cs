using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using TextMod_2.Core;
using TextMod_2.Forms;
using TextMod_2.Variables;

namespace TextMod_2.Controls
{
    public partial class PageRichPresence : UserControl
    {
        bool button1 = false;
        bool button2 = false;
        bool ignoreChangedEvents = false;
        public PageRichPresence()
        {
            InitializeComponent();
        }
        public void PostLoad()
        {
            RichPresenceProfile profile = TextModCore.richPresence;
            profile.OnClientReady += Profile_OnClientReady;
            //profile.OnClientFailed += Profile_OnClientFailed;
            SetPresenceEnabledVisual(profile.presenceEnabled);
            clientIdTextBox.Text = profile.clientID;

            int buttonCount = profile.buttonCount;
            button1 = buttonCount > 0;
            button2 = buttonCount > 1;
            SetButtonsEnabledVisual();

            ignoreChangedEvents = true;
            topTextBox.Text = profile.presence.Details;
            bottomTextBox.Text = profile.presence.State;
            largeImageKeyTextBox.Text = profile.presence.Assets.LargeImageKey;
            largeImageTextBox.Text = profile.presence.Assets.LargeImageText;
            smallImageKeyTextBox.Text = profile.presence.Assets.SmallImageKey;
            smallImageTextBox.Text = profile.presence.Assets.SmallImageText;

            if(button1)
            {
                button1Switch.IsChecked = true;
                button1Text.Text = profile.presence.Buttons[0].Label;
                button1Url.Text = profile.presence.Buttons[0].Url;
            }
            if (button2)
            {
                button2Switch.IsChecked = true;
                button2Text.Text = profile.presence.Buttons[1].Label;
                button2Url.Text = profile.presence.Buttons[1].Url;
            }

            List<RichPresenceVariable> vars = RichPresenceProfile.VARIABLES;
            string[] lines = new string[vars.Count];
            for (int i = 0; i < vars.Count; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(vars[i].Usage);
                while (sb.Length < 30)
                    sb.Append(' ');
                sb.Append("| ");
                sb.Append(vars[i].desc);
                lines[i] = sb.ToString();
            }
            display.Text = string.Join(Environment.NewLine, lines);

            ignoreChangedEvents = false;
        }
        public void SetButtonsEnabledVisual()
        {
            button1Label.Visible = button1;
            button1Url.Visible = button1;
            button1Text.Visible = button1;
            button2Label.Visible = button2;
            button2Url.Visible = button2;
            button2Text.Visible = button2;
        }
        private void SetPresenceEnabledVisual(bool enabled)
        {
            toggleButton.BackColor = enabled ? Color.Salmon : Color.FromArgb(0, 249, 131);
            toggleButton.FlatAppearance.BorderColor = toggleButton.BackColor;
            toggleButton.Text = enabled ? "DISABLE" : "ENABLE";
            toggleButton.ForeColor = Color.Black;
            helpButton.Text = enabled ? "Not showing up?" : "How to get an application ID?";
            clientIdTextBox.Enabled = !enabled;
            toggleButton.Enabled = true;
        }

        private void helpButton_MouseEnter(object sender, EventArgs e)
        {
            helpButton.ForeColor = Color.CornflowerBlue;
        }
        private void helpButton_MouseLeave(object sender, EventArgs e)
        {
            helpButton.ForeColor = SystemColors.Highlight;
        }

        private void toggleButton_Click(object sender, EventArgs e)
        {
            RichPresenceProfile profile = TextModCore.richPresence;
            if(profile.presenceEnabled)
            {
                profile.DisablePresence();
                SetPresenceEnabledVisual(false);
            } else
            {
                string clientID = clientIdTextBox.Text;
                if(!RichPresenceProfile.IsValidClientID(clientID))
                {
                    MessageBox.Show("Invalid application ID. Make sure you're copying the right thing!", "TextMod");
                    return;
                }
                toggleButton.BackColor = Color.FromArgb(75, 75, 75);
                toggleButton.FlatAppearance.BorderColor = toggleButton.BackColor;
                toggleButton.ForeColor = Color.White;
                toggleButton.Text = "...";
                clientIdTextBox.Enabled = false;
                toggleButton.Enabled = false;
                profile.EnablePresence(clientID);
                return;
            }
        }

        delegate void SafeCallSPEV(bool enabled);
        private void Profile_OnClientReady()
        {
            Invoke(new SafeCallSPEV(SetPresenceEnabledVisual), true);
        }
        private void Profile_OnClientFailed()
        {
            Invoke(new SafeCallSPEV(SetPresenceEnabledVisual), false);
        }

        private void button1Switch_OnCheckedChanged(bool isChecked)
        {
            button1 = isChecked;
            if(!isChecked && button2)
            {
                button2Switch.IsChecked = false;
                button2 = false;
            }
            SetButtonsEnabledVisual();
            UpdateButtons();
        }
        private void button2Switch_OnCheckedChanged(bool isChecked)
        {
            if (isChecked && !button1)
            {
                button2Switch.IsChecked = false;
                return;
            }
            button2 = isChecked;
            SetButtonsEnabledVisual();
            UpdateButtons();
        }
        private void UpdateButtons()
        {
            DiscordRPC.Button[] buttons = null;

            try
            {
                int csize = sizeof(char);
                if (button2)
                {
                    buttons = new DiscordRPC.Button[2];
                    buttons[1] = new DiscordRPC.Button();
                    buttons[1].Label = RichPresenceProfile.Limit(button2Text.Text, 32 / csize);
                    buttons[1].Url = RichPresenceProfile.Limit(button2Url.Text, 512 / csize);
                }
                if (button1)
                {
                    if (buttons == null)
                        buttons = new DiscordRPC.Button[1];
                    buttons[0] = new DiscordRPC.Button();
                    buttons[0].Label = RichPresenceProfile.Limit(button1Text.Text, 32 / csize);
                    buttons[0].Url = RichPresenceProfile.Limit(button1Url.Text, 512 / csize);
                }

                TextModCore.richPresence.SetButtons(buttons);
            } catch(Exception) { /* silence */ }
        }
        private void SomeButtonPropertyChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void topTextBox_TextChanged(object sender, EventArgs e)
        {
            if(!ignoreChangedEvents)
                TextModCore.richPresence.UpdateTopText(topTextBox.Text);
        }
        private void bottomTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!ignoreChangedEvents)
                TextModCore.richPresence.UpdateBottomText(bottomTextBox.Text);
        }
        private void largeImageKeyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!ignoreChangedEvents)
                TextModCore.richPresence.UpdateImageKey(ImageKey.LARGE, largeImageKeyTextBox.Text);
        }
        private void largeImageTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!ignoreChangedEvents)
                TextModCore.richPresence.UpdateImageText(ImageKey.LARGE, largeImageTextBox.Text);
        }
        private void smallImageKeyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!ignoreChangedEvents)
                TextModCore.richPresence.UpdateImageKey(ImageKey.SMALL, smallImageKeyTextBox.Text);
        }
        private void smallImageTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!ignoreChangedEvents)
                TextModCore.richPresence.UpdateImageText(ImageKey.SMALL, smallImageTextBox.Text);
        }
        private void display_Enter(object sender, EventArgs e)
        {
            label5.Focus();
        }
        Form helpForm = null;
        private void helpButton_Click(object sender, EventArgs e)
        {
            if (helpForm != null)
            {
                helpForm.Close();
                helpForm.FormClosed -= Opened_FormClosed;
                helpForm.Dispose();
            }

            Form opened;

            if(TextModCore.richPresence.presenceEnabled)
                opened = new RichPresenceNotShowing();
            else
                opened = new RichPresenceGetClientID();

            opened.FormClosed += Opened_FormClosed;
            opened.Show();
            opened.Location = Cursor.Position;
            helpForm = opened;
        }
        private void Opened_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form = sender as Form;
            form.FormClosed -= Opened_FormClosed;
            form.Dispose();
        }
    }
}