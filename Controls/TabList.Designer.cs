
namespace TextMod_2.Controls
{
    partial class TabList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab_UTILITIES = new TextMod_2.Controls.TextModTab();
            this.tab_RICH_PRESENCE = new TextMod_2.Controls.TextModTab();
            this.tab_SCRIPTING = new TextMod_2.Controls.TextModTab();
            this.tab_EMOJI = new TextMod_2.Controls.TextModTab();
            this.tab_IMAGE_COMMANDS = new TextMod_2.Controls.TextModTab();
            this.tab_COMMANDS = new TextMod_2.Controls.TextModTab();
            this.tab_HOME = new TextMod_2.Controls.TextModTab();
            this.SuspendLayout();
            // 
            // tab_UTILITIES
            // 
            this.tab_UTILITIES.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab_UTILITIES.Description = "Auto count, convert data, make broken videos, and so much more!";
            this.tab_UTILITIES.Location = new System.Drawing.Point(3, 545);
            this.tab_UTILITIES.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tab_UTILITIES.Name = "tab_UTILITIES";
            this.tab_UTILITIES.Page = TextMod_2.Core.TextModPage.UTILITIES;
            this.tab_UTILITIES.Size = new System.Drawing.Size(260, 73);
            this.tab_UTILITIES.TabIndex = 0;
            this.tab_UTILITIES.Title = "UTILITIES";
            // 
            // tab_RICH_PRESENCE
            // 
            this.tab_RICH_PRESENCE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab_RICH_PRESENCE.Description = "Customize and create an interactive or animated rich presence!";
            this.tab_RICH_PRESENCE.Location = new System.Drawing.Point(3, 469);
            this.tab_RICH_PRESENCE.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tab_RICH_PRESENCE.Name = "tab_RICH_PRESENCE";
            this.tab_RICH_PRESENCE.Page = TextMod_2.Core.TextModPage.RICH_PRESENCE;
            this.tab_RICH_PRESENCE.Size = new System.Drawing.Size(260, 73);
            this.tab_RICH_PRESENCE.TabIndex = 0;
            this.tab_RICH_PRESENCE.Title = "RICH PRESENCE";
            // 
            // tab_SCRIPTING
            // 
            this.tab_SCRIPTING.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab_SCRIPTING.Description = "Write your own commands and create snippets of text!";
            this.tab_SCRIPTING.Location = new System.Drawing.Point(3, 393);
            this.tab_SCRIPTING.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tab_SCRIPTING.Name = "tab_SCRIPTING";
            this.tab_SCRIPTING.Page = TextMod_2.Core.TextModPage.SCRIPTING;
            this.tab_SCRIPTING.Size = new System.Drawing.Size(260, 73);
            this.tab_SCRIPTING.TabIndex = 0;
            this.tab_SCRIPTING.Title = "SCRIPTING";
            // 
            // tab_EMOJI
            // 
            this.tab_EMOJI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab_EMOJI.Description = "Use custom emoji even without Discord Nitro!";
            this.tab_EMOJI.Location = new System.Drawing.Point(3, 317);
            this.tab_EMOJI.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tab_EMOJI.Name = "tab_EMOJI";
            this.tab_EMOJI.Page = TextMod_2.Core.TextModPage.EMOJI;
            this.tab_EMOJI.Size = new System.Drawing.Size(260, 73);
            this.tab_EMOJI.TabIndex = 0;
            this.tab_EMOJI.Title = "EMOJI";
            // 
            // tab_IMAGE_COMMANDS
            // 
            this.tab_IMAGE_COMMANDS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab_IMAGE_COMMANDS.Description = "Mess around with or generate new images with these!";
            this.tab_IMAGE_COMMANDS.Location = new System.Drawing.Point(3, 241);
            this.tab_IMAGE_COMMANDS.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tab_IMAGE_COMMANDS.Name = "tab_IMAGE_COMMANDS";
            this.tab_IMAGE_COMMANDS.Page = TextMod_2.Core.TextModPage.IMAGE_COMMANDS;
            this.tab_IMAGE_COMMANDS.Size = new System.Drawing.Size(260, 73);
            this.tab_IMAGE_COMMANDS.TabIndex = 0;
            this.tab_IMAGE_COMMANDS.Title = "IMAGE COMMANDS";
            // 
            // tab_COMMANDS
            // 
            this.tab_COMMANDS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab_COMMANDS.Description = "All of the TextMod commands and how to use them!";
            this.tab_COMMANDS.Location = new System.Drawing.Point(3, 126);
            this.tab_COMMANDS.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tab_COMMANDS.Name = "tab_COMMANDS";
            this.tab_COMMANDS.Page = TextMod_2.Core.TextModPage.COMMANDS;
            this.tab_COMMANDS.Size = new System.Drawing.Size(260, 112);
            this.tab_COMMANDS.TabIndex = 0;
            this.tab_COMMANDS.Title = "COMMANDS";
            // 
            // tab_HOME
            // 
            this.tab_HOME.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab_HOME.Description = "Your TextMod home screen.";
            this.tab_HOME.Location = new System.Drawing.Point(3, 3);
            this.tab_HOME.Name = "tab_HOME";
            this.tab_HOME.Page = TextMod_2.Core.TextModPage.HOME;
            this.tab_HOME.Size = new System.Drawing.Size(260, 120);
            this.tab_HOME.TabIndex = 0;
            this.tab_HOME.Title = "HOME";
            // 
            // TabList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.Controls.Add(this.tab_UTILITIES);
            this.Controls.Add(this.tab_RICH_PRESENCE);
            this.Controls.Add(this.tab_SCRIPTING);
            this.Controls.Add(this.tab_EMOJI);
            this.Controls.Add(this.tab_IMAGE_COMMANDS);
            this.Controls.Add(this.tab_COMMANDS);
            this.Controls.Add(this.tab_HOME);
            this.Name = "TabList";
            this.Size = new System.Drawing.Size(266, 621);
            this.ResumeLayout(false);

        }

        #endregion

        private TextModTab tab_HOME;
        private TextModTab tab_COMMANDS;
        private TextModTab tab_IMAGE_COMMANDS;
        private TextModTab tab_EMOJI;
        private TextModTab tab_SCRIPTING;
        private TextModTab tab_RICH_PRESENCE;
        private TextModTab tab_UTILITIES;
    }
}
