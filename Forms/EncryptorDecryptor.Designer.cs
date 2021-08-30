
namespace TextMod_2.Forms
{
    partial class EncryptorDecryptor
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
            this.topBox = new System.Windows.Forms.TextBox();
            this.encryptButton = new System.Windows.Forms.Button();
            this.encryptionTypeBox = new System.Windows.Forms.ComboBox();
            this.bottomBox = new System.Windows.Forms.TextBox();
            this.decryptButton = new System.Windows.Forms.Button();
            this.seedTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // topBox
            // 
            this.topBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topBox.Location = new System.Drawing.Point(12, 12);
            this.topBox.Multiline = true;
            this.topBox.Name = "topBox";
            this.topBox.Size = new System.Drawing.Size(541, 215);
            this.topBox.TabIndex = 0;
            // 
            // encryptButton
            // 
            this.encryptButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encryptButton.Location = new System.Drawing.Point(12, 232);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(90, 29);
            this.encryptButton.TabIndex = 1;
            this.encryptButton.Text = "\\/";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // encryptionTypeBox
            // 
            this.encryptionTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encryptionTypeBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.encryptionTypeBox.FormattingEnabled = true;
            this.encryptionTypeBox.Location = new System.Drawing.Point(108, 233);
            this.encryptionTypeBox.Name = "encryptionTypeBox";
            this.encryptionTypeBox.Size = new System.Drawing.Size(349, 29);
            this.encryptionTypeBox.TabIndex = 2;
            this.encryptionTypeBox.SelectedIndexChanged += new System.EventHandler(this.encryptionTypeBox_SelectedIndexChanged);
            // 
            // bottomBox
            // 
            this.bottomBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bottomBox.Location = new System.Drawing.Point(12, 268);
            this.bottomBox.Multiline = true;
            this.bottomBox.Name = "bottomBox";
            this.bottomBox.Size = new System.Drawing.Size(541, 215);
            this.bottomBox.TabIndex = 0;
            // 
            // decryptButton
            // 
            this.decryptButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decryptButton.Location = new System.Drawing.Point(463, 232);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(90, 29);
            this.decryptButton.TabIndex = 3;
            this.decryptButton.Text = "/\\";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // seedTextBox
            // 
            this.seedTextBox.Location = new System.Drawing.Point(12, 489);
            this.seedTextBox.Name = "seedTextBox";
            this.seedTextBox.Size = new System.Drawing.Size(541, 20);
            this.seedTextBox.TabIndex = 4;
            this.seedTextBox.Text = "PUT SEED HERE";
            // 
            // EncryptorDecryptor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 489);
            this.Controls.Add(this.seedTextBox);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.encryptionTypeBox);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.bottomBox);
            this.Controls.Add(this.topBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EncryptorDecryptor";
            this.Text = "TextMod - Encryptor/Decryptor";
            this.Load += new System.EventHandler(this.EncryptorDecryptor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox topBox;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.ComboBox encryptionTypeBox;
        private System.Windows.Forms.TextBox bottomBox;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.TextBox seedTextBox;
    }
}