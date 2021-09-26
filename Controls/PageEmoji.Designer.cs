
namespace TextMod_2.Controls
{
    partial class PageEmoji
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.display = new System.Windows.Forms.ListBox();
            this.renameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.deselectButton = new System.Windows.Forms.Button();
            this.emojiPreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.emojiPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(249)))), ((int)(((byte)(131)))));
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 65);
            this.label1.TabIndex = 4;
            this.label1.Text = "EMOJI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(809, 64);
            this.label2.TabIndex = 5;
            this.label2.Text = "When you type                         and press F12, an image will be automatical" +
    "ly\r\nresized and sent in discord to make it look just like a nitro emoji!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(195, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = ":emoji_name:";
            // 
            // display
            // 
            this.display.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.display.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.display.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.display.ForeColor = System.Drawing.Color.White;
            this.display.FormattingEnabled = true;
            this.display.ItemHeight = 30;
            this.display.Location = new System.Drawing.Point(26, 169);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(411, 420);
            this.display.TabIndex = 7;
            this.display.SelectedIndexChanged += new System.EventHandler(this.display_SelectedIndexChanged);
            // 
            // renameTextBox
            // 
            this.renameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.renameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.renameTextBox.Enabled = false;
            this.renameTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.renameTextBox.ForeColor = System.Drawing.Color.White;
            this.renameTextBox.Location = new System.Drawing.Point(465, 204);
            this.renameTextBox.Name = "renameTextBox";
            this.renameTextBox.Size = new System.Drawing.Size(521, 32);
            this.renameTextBox.TabIndex = 8;
            this.renameTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.renameTextBox_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(459, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "Rename Emoji";
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.addButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Location = new System.Drawing.Point(465, 274);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(521, 32);
            this.addButton.TabIndex = 10;
            this.addButton.Text = "ADD EMOJI";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(459, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 32);
            this.label5.TabIndex = 9;
            this.label5.Text = "Modify List";
            // 
            // removeButton
            // 
            this.removeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.removeButton.Enabled = false;
            this.removeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.removeButton.FlatAppearance.BorderSize = 0;
            this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.removeButton.ForeColor = System.Drawing.Color.White;
            this.removeButton.Location = new System.Drawing.Point(465, 312);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(521, 32);
            this.removeButton.TabIndex = 10;
            this.removeButton.Text = "REMOVE EMOJI";
            this.removeButton.UseVisualStyleBackColor = false;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Image Files (.png, .jpg)|*.png;*.jpg";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Select one or more images to add to your emoji collection!";
            // 
            // deselectButton
            // 
            this.deselectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.deselectButton.Enabled = false;
            this.deselectButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.deselectButton.FlatAppearance.BorderSize = 0;
            this.deselectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deselectButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.deselectButton.ForeColor = System.Drawing.Color.White;
            this.deselectButton.Location = new System.Drawing.Point(861, 539);
            this.deselectButton.Name = "deselectButton";
            this.deselectButton.Size = new System.Drawing.Size(125, 50);
            this.deselectButton.TabIndex = 10;
            this.deselectButton.Text = "DESELECT";
            this.deselectButton.UseVisualStyleBackColor = false;
            this.deselectButton.Click += new System.EventHandler(this.deselectButton_Click);
            // 
            // emojiPreview
            // 
            this.emojiPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.emojiPreview.Location = new System.Drawing.Point(805, 539);
            this.emojiPreview.Name = "emojiPreview";
            this.emojiPreview.Size = new System.Drawing.Size(50, 50);
            this.emojiPreview.TabIndex = 11;
            this.emojiPreview.TabStop = false;
            // 
            // PageEmoji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.Controls.Add(this.emojiPreview);
            this.Controls.Add(this.deselectButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.renameTextBox);
            this.Controls.Add(this.display);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PageEmoji";
            this.Size = new System.Drawing.Size(1014, 620);
            ((System.ComponentModel.ISupportInitialize)(this.emojiPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox display;
        private System.Windows.Forms.TextBox renameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button deselectButton;
        private System.Windows.Forms.PictureBox emojiPreview;
    }
}
