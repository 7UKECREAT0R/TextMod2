
namespace TextMod_2.Forms.Art
{
    partial class AsciiArtText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsciiArtText));
            this.display = new System.Windows.Forms.Label();
            this.copyButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // display
            // 
            this.display.AutoSize = true;
            this.display.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.display.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.display.Location = new System.Drawing.Point(12, 9);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(972, 520);
            this.display.TabIndex = 0;
            this.display.Text = resources.GetString("display.Text");
            this.display.MouseDown += new System.Windows.Forms.MouseEventHandler(this.display_MouseDown);
            this.display.MouseLeave += new System.EventHandler(this.display_MouseLeave);
            this.display.MouseMove += new System.Windows.Forms.MouseEventHandler(this.display_MouseMove);
            this.display.MouseUp += new System.Windows.Forms.MouseEventHandler(this.display_MouseUp);
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(17, 566);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(966, 123);
            this.copyButton.TabIndex = 5;
            this.copyButton.Text = "Copy to Clipboard";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(17, 532);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(966, 28);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // AsciiArtText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 703);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.display);
            this.DoubleBuffered = true;
            this.Name = "AsciiArtText";
            this.Text = "AsciiArt - Text";
            this.Load += new System.EventHandler(this.AsciiArtText_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label display;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button clearButton;
    }
}