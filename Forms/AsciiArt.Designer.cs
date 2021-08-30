
namespace TextMod_2.Forms
{
    partial class AsciiArt
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
            this.emojiButton = new System.Windows.Forms.Button();
            this.textButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose a \"canvas\" to get started with.";
            // 
            // emojiButton
            // 
            this.emojiButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emojiButton.Location = new System.Drawing.Point(16, 42);
            this.emojiButton.Name = "emojiButton";
            this.emojiButton.Size = new System.Drawing.Size(391, 39);
            this.emojiButton.TabIndex = 1;
            this.emojiButton.Text = "EMOJI (12x12)";
            this.emojiButton.UseVisualStyleBackColor = true;
            this.emojiButton.Click += new System.EventHandler(this.emojiButton_Click);
            // 
            // textButton
            // 
            this.textButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textButton.Location = new System.Drawing.Point(16, 87);
            this.textButton.Name = "textButton";
            this.textButton.Size = new System.Drawing.Size(391, 39);
            this.textButton.TabIndex = 1;
            this.textButton.Text = "TEXT (80x25)";
            this.textButton.UseVisualStyleBackColor = true;
            this.textButton.Click += new System.EventHandler(this.textButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "choose image";
            this.openFileDialog.Filter = "Image Files (PNG, JPG)|*.png;*.jpg";
            this.openFileDialog.Title = "Pick an image to convert...";
            // 
            // AsciiArt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 138);
            this.Controls.Add(this.textButton);
            this.Controls.Add(this.emojiButton);
            this.Controls.Add(this.label1);
            this.Name = "AsciiArt";
            this.Text = "AsciiArt Launcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button emojiButton;
        private System.Windows.Forms.Button textButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}