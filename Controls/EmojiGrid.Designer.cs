﻿
namespace TextMod_2.Controls
{
    partial class EmojiGrid
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
            this.SuspendLayout();
            // 
            // EmojiGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Magenta;
            this.DoubleBuffered = true;
            this.Name = "EmojiGrid";
            this.Size = new System.Drawing.Size(288, 288);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EmojiGrid_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EmojiGrid_MouseDown);
            this.MouseLeave += new System.EventHandler(this.EmojiGrid_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EmojiGrid_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EmojiGrid_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
