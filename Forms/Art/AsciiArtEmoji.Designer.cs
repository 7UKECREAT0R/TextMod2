
namespace TextMod_2.Forms.Art
{
    partial class AsciiArtEmoji
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
            this.brushType = new System.Windows.Forms.ComboBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.emojiGrid = new TextMod_2.Controls.EmojiGrid();
            this.SuspendLayout();
            // 
            // brushType
            // 
            this.brushType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.brushType.FormattingEnabled = true;
            this.brushType.Location = new System.Drawing.Point(126, 306);
            this.brushType.Name = "brushType";
            this.brushType.Size = new System.Drawing.Size(174, 21);
            this.brushType.TabIndex = 1;
            this.brushType.SelectedIndexChanged += new System.EventHandler(this.brushType_SelectedIndexChanged);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(12, 306);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(106, 23);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(12, 335);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(288, 72);
            this.copyButton.TabIndex = 2;
            this.copyButton.Text = "Copy to Clipboard";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // emojiGrid
            // 
            this.emojiGrid.BackColor = System.Drawing.Color.Magenta;
            this.emojiGrid.Location = new System.Drawing.Point(12, 12);
            this.emojiGrid.Name = "emojiGrid";
            this.emojiGrid.Size = new System.Drawing.Size(288, 288);
            this.emojiGrid.TabIndex = 0;
            // 
            // AsciiArtEmoji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 420);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.brushType);
            this.Controls.Add(this.emojiGrid);
            this.Name = "AsciiArtEmoji";
            this.Text = "AsciiArt - Emoji";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.EmojiGrid emojiGrid;
        private System.Windows.Forms.ComboBox brushType;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button copyButton;
    }
}