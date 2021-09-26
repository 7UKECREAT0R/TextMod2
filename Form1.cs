using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextMod_2.Core;
using TextMod_2.Styling;

namespace TextMod_2
{
    public partial class Form1 : Form
    {
        Dictionary<TextModPage, UserControl> pages = new Dictionary<TextModPage, UserControl>();

        bool bubbleShown;
        internal TextModCore textMod;
        internal FontLoader fonts;

        ContextMenuStrip notifyContextMenu = new ContextMenuStrip();

        public Form1()
        {
            InitializeComponent();

            try
            {
                SplashForm.STATUS = "Initialize context menu...";
                InitializeContextMenu();

                // events
                tabList.OnPageSwitched += TabList_OnPageSwitched;

                // use the panel and label as a handle for the form
                SplashForm.STATUS = "Form design...";
                Visuals.MakeHandle(dragPanel, this);
                Visuals.MakeHandle(title, this);
                Visuals.RoundRegion(this, 5);

                // set working directory
                SplashForm.STATUS = "Setting working directory...";
                System.IO.Directory.SetCurrentDirectory(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

                SplashForm.STATUS = "Initialize TextMod Core...";
                textMod = new TextModCore();
                textMod.Initialize();

                SplashForm.STATUS = "Building pages...";
                pageHome.SetSwitches();
                pageCommands.SetCommands(textMod.commands);
                pageImageCommands.SetCommands(textMod.commands);
                pageEmoji.BuildDisplay();

                SplashForm.STATUS = "Applying scripts...";
                if (TextModCore.scriptingEnabled)
                    pageScripts.SetScripts(textMod.scripts);

                SplashForm.STATUS = "Initialize fonts...";
                fonts = new FontLoader();

                if (textMod.processID == -1)
                    pageHome.AllowAttaching(ref textMod);

                SplashForm.STATUS = "Check start menu entry...";
                string startMenu = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
                string shortcut = System.IO.Path.Combine(startMenu, "Programs", "TextMod 2.lnk");
                string target = Assembly.GetEntryAssembly().Location;
                if (!System.IO.File.Exists(shortcut))
                {
                    WshShell shell = new WshShell();
                    IWshShortcut creating = (IWshShortcut)shell.CreateShortcut(shortcut);
                    creating.Description = "TextMod 2 Launcher";
                    creating.TargetPath = target;
                    creating.Save();
                }

                // textmodpage -> respective usercontrol
                SplashForm.STATUS = "Finalize pages...";
                pages.Add(TextModPage.HOME, pageHome);
                pages.Add(TextModPage.COMMANDS, pageCommands);
                pages.Add(TextModPage.IMAGE_COMMANDS, pageImageCommands);
                pages.Add(TextModPage.EMOJI, pageEmoji);
                pages.Add(TextModPage.SCRIPTING, pageScripts);
                pages.Add(TextModPage.RICH_PRESENCE, pageRichPresence);
                pages.Add(TextModPage.UTILITIES, pageUtilities);

                SplashForm.STATUS = "Collect rich presence variables...";
                TextModCore.richPresence.LoadVariables();

                SplashForm.STATUS = "Post-setup actions...";
                pageRichPresence.PostLoad();
            } catch(Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Fatal Loading Error");
                return;
            }
        }
        private void InitializeContextMenu()
        {
            foreach (TextModPage page in Enum.GetValues(typeof(TextModPage)))
                notifyContextMenu.Items.Add(Enum.GetName(typeof(TextModPage), page)
                .Replace('_', ' '), null, (sender, e) => { NotifyIconPageClick(page); });

            notifyContextMenu.Items.Add("--------");
            notifyContextMenu.Items.Add("EXIT TEXTMOD", SystemIcons.Error.ToBitmap(), exitButton_Click);
        }
        private void NotifyIconPageClick(TextModPage page)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
            tabList.ExternalSelectPage(page);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon.ContextMenuStrip = notifyContextMenu;
            //fonts.BindFont(ref title, FontLoader.BEBAS);

            Updater updater = new Updater();
            updater.FetchReleases();

            if(!updater.IsOnLatest)
            {
                if(MessageBox.Show("A new release is ready to download. Would you like to update now?", "TextMod Updater", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Download latest update.
                    MouseHook.Stop();
                    string downloadURL = updater.LatestReleaseURL;
                    string downloadFile = "update.zip";
                    if (System.IO.File.Exists(downloadFile))
                        System.IO.File.Delete(downloadFile);
                    using (WebClient wc = new WebClient())
                        wc.DownloadFile(downloadURL, downloadFile);
                    Process.Start("updater.exe");
                    Environment.Exit(0);
                    return;
                }
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            tabList.OnPageSwitched -= TabList_OnPageSwitched;
            notifyIcon.Visible = false;
            textMod?.Dispose();
            notifyContextMenu.Dispose();
        }
        private void TabList_OnPageSwitched(TextModPage newPage)
        {
            TransitionTo(newPage);
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
                WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;
            }
        }
        private void processValidator_Tick(object sender, EventArgs e)
        {
            if (textMod.processID == -1)
            {
                // Search again
                textMod.LocateDiscordProcess();
                if (textMod.processID != -1)
                    pageHome.StopAttaching(ref textMod);
                return;
            }

            int pid = textMod.processID;
            try
            {
                Process.GetProcessById(pid);
            } catch(Exception)
            {
                Show();
                WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;
                textMod.processID = -1;
                pageHome.AllowAttaching(ref textMod);
                tabList.GoHome();
                // MessageBox.Show("Lost the discord process! Press \"Attach to Discord\" when it's back.", "TextMod", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void TransitionTo(TextModPage page)
        {
            if (!pages.TryGetValue(page, out UserControl target))
                return;
            target.BringToFront();
        }
        public void Minimize()
        {
            Hide();
            notifyIcon.Visible = true;
            if (!bubbleShown)
            {
                bubbleShown = true;
                notifyIcon.ShowBalloonTip(3500);
            }
        }
    }
}
