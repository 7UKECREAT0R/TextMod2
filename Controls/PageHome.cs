using Microsoft.Win32;
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

namespace TextMod_2.Controls
{
    public partial class PageHome : UserControl
    {
        public PageHome()
        {
            InitializeComponent();
            switchStartup.OnCheckedChanged += SwitchStartup_OnCheckedChanged;
            switchPerformance.OnCheckedChanged += SwitchPerformance_OnCheckedChanged;
            switchScripting.OnCheckedChanged += SwitchScripting_OnCheckedChanged;
        }

        private void SwitchStartup_OnCheckedChanged(bool isChecked)
        {
            TextModCore.runOnStartup = isChecked;
            SetStartup(isChecked);
            TextModCore.WriteMainSettings();
        }
        private void SwitchPerformance_OnCheckedChanged(bool isChecked)
        {
            TextModCore.performanceMode = isChecked;
            TextModCore.WriteMainSettings();
        }
        private void SwitchScripting_OnCheckedChanged(bool isChecked)
        {
            TextModCore.scriptingEnabled = isChecked;
            TextModCore.WriteMainSettings();
            MessageBox.Show("For changes to take effect, you need to restart TextMod.");
        }

        TextModCore coreReference;
        public void AllowAttaching(ref TextModCore core)
        {
            coreReference = core;
            attachButton.Enabled = true;
            attachButton.Visible = true;
            hideButton.Enabled = false;
            attachButton.BringToFront();
        }
        public void StopAttaching(ref TextModCore core)
        {
            coreReference = core;
            attachButton.Enabled = false;
            attachButton.Visible = false;
            hideButton.Enabled = true;
            hideButton.Visible = true;
            attachButton.SendToBack();
        }
        public void SetSwitches()
        {
            SetStartup(TextModCore.runOnStartup);
            switchStartup.IsChecked = TextModCore.runOnStartup;
            switchPerformance.IsChecked = TextModCore.performanceMode;
            switchScripting.IsChecked = TextModCore.scriptingEnabled;
        }
        private void attachButton_Click(object sender, EventArgs e)
        {
            if (coreReference == null)
            {
                MessageBox.Show("you shouldnt be allowed to click this...");
                attachButton.Enabled = false;
                attachButton.Visible = false;
                hideButton.Enabled = true;
                attachButton.SendToBack();
                return;
            }
            coreReference.LocateDiscordProcess();
            if (coreReference.processID != -1)
            {
                attachButton.Enabled = false;
                attachButton.Visible = false;
                hideButton.Enabled = true;
                attachButton.SendToBack();
                return;
            }
        }
        private void hideButton_Click(object sender, EventArgs e)
        {
            (ParentForm as Form1).Minimize();
        }

        const string APP = "TextMod2";
        private void SetStartup(bool enable)
        {
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                if (enable)
                {
                    rk.DeleteValue(APP, false);
                    rk.SetValue(APP, Application.ExecutablePath);
                }
                else
                    rk.DeleteValue(APP, false);
            }
        }
    }
}
