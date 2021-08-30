
namespace TextMod_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.title = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.dragPanel = new System.Windows.Forms.Panel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.processValidator = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.pageHome = new TextMod_2.Controls.PageHome();
            this.tabList = new TextMod_2.Controls.TabList();
            this.pageCommands = new TextMod_2.Controls.PageCommands();
            this.pageImageCommands = new TextMod_2.Controls.PageImageCommands();
            this.pageEmoji = new TextMod_2.Controls.PageEmoji();
            this.pageScripts = new TextMod_2.Controls.PageScripts();
            this.pageRichPresence = new TextMod_2.Controls.PageRichPresence();
            this.pageUtilities = new TextMod_2.Controls.PageUtilities();
            this.dragPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Tw Cen MT Condensed", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(252)))), ((int)(((byte)(177)))));
            this.title.Location = new System.Drawing.Point(12, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(638, 76);
            this.title.TabIndex = 0;
            this.title.Text = "TEXTMOD 2.0";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // exitButton
            // 
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exitButton.Location = new System.Drawing.Point(1204, 26);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(49, 45);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "X";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // dragPanel
            // 
            this.dragPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dragPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.dragPanel.Controls.Add(this.exitButton);
            this.dragPanel.Controls.Add(this.title);
            this.dragPanel.Location = new System.Drawing.Point(0, 0);
            this.dragPanel.Name = "dragPanel";
            this.dragPanel.Size = new System.Drawing.Size(1280, 100);
            this.dragPanel.TabIndex = 0;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "TextMod is now minimized to the system tray! Click on the icon to bring it back.";
            this.notifyIcon.BalloonTipTitle = "TextMod";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "TextMod 2 - Running";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // processValidator
            // 
            this.processValidator.Enabled = true;
            this.processValidator.Interval = 2000;
            this.processValidator.Tick += new System.EventHandler(this.processValidator_Tick);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI Semilight", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1097, 700);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "developed by 7UKECREAT0R @ 2021";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // pageHome
            // 
            this.pageHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pageHome.Location = new System.Drawing.Point(266, 100);
            this.pageHome.Name = "pageHome";
            this.pageHome.Size = new System.Drawing.Size(1014, 620);
            this.pageHome.TabIndex = 2;
            // 
            // tabList
            // 
            this.tabList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.tabList.Location = new System.Drawing.Point(0, 99);
            this.tabList.Name = "tabList";
            this.tabList.Size = new System.Drawing.Size(266, 621);
            this.tabList.TabIndex = 1;
            // 
            // pageCommands
            // 
            this.pageCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pageCommands.Location = new System.Drawing.Point(266, 100);
            this.pageCommands.Name = "pageCommands";
            this.pageCommands.Size = new System.Drawing.Size(1014, 620);
            this.pageCommands.TabIndex = 4;
            // 
            // pageImageCommands
            // 
            this.pageImageCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pageImageCommands.Location = new System.Drawing.Point(266, 100);
            this.pageImageCommands.Name = "pageImageCommands";
            this.pageImageCommands.Size = new System.Drawing.Size(1014, 620);
            this.pageImageCommands.TabIndex = 5;
            // 
            // pageEmoji
            // 
            this.pageEmoji.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pageEmoji.Location = new System.Drawing.Point(266, 100);
            this.pageEmoji.Name = "pageEmoji";
            this.pageEmoji.Size = new System.Drawing.Size(1014, 620);
            this.pageEmoji.TabIndex = 6;
            // 
            // pageScripts
            // 
            this.pageScripts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pageScripts.Location = new System.Drawing.Point(266, 100);
            this.pageScripts.Name = "pageScripts";
            this.pageScripts.Size = new System.Drawing.Size(1014, 620);
            this.pageScripts.TabIndex = 7;
            // 
            // pageRichPresence
            // 
            this.pageRichPresence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pageRichPresence.Location = new System.Drawing.Point(266, 100);
            this.pageRichPresence.Name = "pageRichPresence";
            this.pageRichPresence.Size = new System.Drawing.Size(1014, 620);
            this.pageRichPresence.TabIndex = 8;
            // 
            // pageUtilities
            // 
            this.pageUtilities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pageUtilities.Location = new System.Drawing.Point(266, 100);
            this.pageUtilities.Name = "pageUtilities";
            this.pageUtilities.Size = new System.Drawing.Size(1014, 620);
            this.pageUtilities.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.pageHome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dragPanel);
            this.Controls.Add(this.tabList);
            this.Controls.Add(this.pageCommands);
            this.Controls.Add(this.pageImageCommands);
            this.Controls.Add(this.pageEmoji);
            this.Controls.Add(this.pageScripts);
            this.Controls.Add(this.pageRichPresence);
            this.Controls.Add(this.pageUtilities);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "TextMod";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.dragPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Panel dragPanel;
        private Controls.TabList tabList;
        private Controls.PageHome pageHome;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Timer processValidator;
        private System.Windows.Forms.Label label3;
        private Controls.PageCommands pageCommands;
        private Controls.PageImageCommands pageImageCommands;
        private Controls.PageEmoji pageEmoji;
        private Controls.PageScripts pageScripts;
        private Controls.PageRichPresence pageRichPresence;
        private Controls.PageUtilities pageUtilities;
    }
}

