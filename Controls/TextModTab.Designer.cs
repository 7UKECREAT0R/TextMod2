
namespace TextMod_2.Controls
{
    partial class TextModTab
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
            this.components = new System.ComponentModel.Container();
            this.titleLabel = new System.Windows.Forms.Label();
            this.descLabel = new System.Windows.Forms.Label();
            this.animationEvents = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(244)))), ((int)(((byte)(165)))));
            this.titleLabel.Location = new System.Drawing.Point(4, 1);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(249, 31);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "TITLE";
            this.titleLabel.Click += new System.EventHandler(this.TabSelect);
            this.titleLabel.MouseEnter += new System.EventHandler(this.TextModTab_MouseEnter);
            this.titleLabel.MouseLeave += new System.EventHandler(this.TextModTab_MouseLeave);
            // 
            // descLabel
            // 
            this.descLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descLabel.ForeColor = System.Drawing.Color.White;
            this.descLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.descLabel.Location = new System.Drawing.Point(4, 29);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(249, 41);
            this.descLabel.TabIndex = 0;
            this.descLabel.Text = "This is a multiline label that describes the tab\'s contents; etc...";
            this.descLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.descLabel.Click += new System.EventHandler(this.TabSelect);
            this.descLabel.MouseEnter += new System.EventHandler(this.TextModTab_MouseEnter);
            this.descLabel.MouseLeave += new System.EventHandler(this.TextModTab_MouseLeave);
            // 
            // animationEvents
            // 
            this.animationEvents.Enabled = true;
            this.animationEvents.Interval = 16;
            this.animationEvents.Tick += new System.EventHandler(this.animationEvents_Tick);
            // 
            // TextModTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.descLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "TextModTab";
            this.Size = new System.Drawing.Size(260, 73);
            this.Click += new System.EventHandler(this.TabSelect);
            this.MouseEnter += new System.EventHandler(this.TextModTab_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.TextModTab_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.Timer animationEvents;
    }
}
