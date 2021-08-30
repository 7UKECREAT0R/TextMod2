
namespace TextMod_2.Forms
{
    partial class ZipFileHider
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.chooseZip = new System.Windows.Forms.Button();
            this.displayBox = new System.Windows.Forms.TextBox();
            this.filesInside = new System.Windows.Forms.ListBox();
            this.hideButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.hiddenFilesDisplay = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.restoreAllFilesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zip File Hider";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(434, 68);
            this.label2.TabIndex = 0;
            this.label2.Text = "This modifies the file table in a .ZIP file to make a file appear like it\'s not t" +
    "here. It cannot be extracted once it\'s hidden, but it can be restored through th" +
    "is program. ";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Zip Files|*.zip";
            // 
            // chooseZip
            // 
            this.chooseZip.Location = new System.Drawing.Point(12, 125);
            this.chooseZip.Name = "chooseZip";
            this.chooseZip.Size = new System.Drawing.Size(99, 20);
            this.chooseZip.TabIndex = 1;
            this.chooseZip.Text = "Choose ZIP";
            this.chooseZip.UseVisualStyleBackColor = true;
            this.chooseZip.Click += new System.EventHandler(this.chooseZip_Click);
            this.chooseZip.DragDrop += new System.Windows.Forms.DragEventHandler(this.chooseZip_DragDrop);
            this.chooseZip.DragEnter += new System.Windows.Forms.DragEventHandler(this.chooseZip_DragEnter);
            // 
            // displayBox
            // 
            this.displayBox.Location = new System.Drawing.Point(117, 125);
            this.displayBox.Name = "displayBox";
            this.displayBox.ReadOnly = true;
            this.displayBox.Size = new System.Drawing.Size(333, 20);
            this.displayBox.TabIndex = 2;
            // 
            // filesInside
            // 
            this.filesInside.FormattingEnabled = true;
            this.filesInside.Location = new System.Drawing.Point(12, 151);
            this.filesInside.Name = "filesInside";
            this.filesInside.Size = new System.Drawing.Size(438, 82);
            this.filesInside.TabIndex = 3;
            this.filesInside.SelectedIndexChanged += new System.EventHandler(this.filesInside_SelectedIndexChanged);
            // 
            // hideButton
            // 
            this.hideButton.Enabled = false;
            this.hideButton.Location = new System.Drawing.Point(12, 239);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(438, 26);
            this.hideButton.TabIndex = 1;
            this.hideButton.Text = "Hide file...";
            this.hideButton.UseVisualStyleBackColor = true;
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            this.hideButton.DragDrop += new System.Windows.Forms.DragEventHandler(this.chooseZip_DragDrop);
            this.hideButton.DragEnter += new System.Windows.Forms.DragEventHandler(this.chooseZip_DragEnter);
            // 
            // searchButton
            // 
            this.searchButton.Enabled = false;
            this.searchButton.Location = new System.Drawing.Point(12, 297);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(438, 26);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search for hidden files";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            this.searchButton.DragDrop += new System.Windows.Forms.DragEventHandler(this.chooseZip_DragDrop);
            this.searchButton.DragEnter += new System.Windows.Forms.DragEventHandler(this.chooseZip_DragEnter);
            // 
            // hiddenFilesDisplay
            // 
            this.hiddenFilesDisplay.FormattingEnabled = true;
            this.hiddenFilesDisplay.Location = new System.Drawing.Point(12, 329);
            this.hiddenFilesDisplay.Name = "hiddenFilesDisplay";
            this.hiddenFilesDisplay.Size = new System.Drawing.Size(438, 69);
            this.hiddenFilesDisplay.TabIndex = 3;
            this.hiddenFilesDisplay.SelectedIndexChanged += new System.EventHandler(this.hiddenFilesDisplay_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Location = new System.Drawing.Point(12, 275);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 10);
            this.panel1.TabIndex = 4;
            // 
            // restoreAllFilesButton
            // 
            this.restoreAllFilesButton.Enabled = false;
            this.restoreAllFilesButton.Location = new System.Drawing.Point(12, 404);
            this.restoreAllFilesButton.Name = "restoreAllFilesButton";
            this.restoreAllFilesButton.Size = new System.Drawing.Size(438, 26);
            this.restoreAllFilesButton.TabIndex = 1;
            this.restoreAllFilesButton.Text = "Restore found files";
            this.restoreAllFilesButton.UseVisualStyleBackColor = true;
            this.restoreAllFilesButton.Click += new System.EventHandler(this.restoreAllFilesButton_Click);
            this.restoreAllFilesButton.DragDrop += new System.Windows.Forms.DragEventHandler(this.chooseZip_DragDrop);
            this.restoreAllFilesButton.DragEnter += new System.Windows.Forms.DragEventHandler(this.chooseZip_DragEnter);
            // 
            // ZipFileHider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 440);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.hiddenFilesDisplay);
            this.Controls.Add(this.filesInside);
            this.Controls.Add(this.displayBox);
            this.Controls.Add(this.restoreAllFilesButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.hideButton);
            this.Controls.Add(this.chooseZip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ZipFileHider";
            this.ShowIcon = false;
            this.Text = "TextMod - Zip File Hider";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button chooseZip;
        private System.Windows.Forms.TextBox displayBox;
        private System.Windows.Forms.ListBox filesInside;
        private System.Windows.Forms.Button hideButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ListBox hiddenFilesDisplay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button restoreAllFilesButton;
    }
}