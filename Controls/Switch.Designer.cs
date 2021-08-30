
namespace TextMod_2.Controls
{
    partial class Switch
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
            this.label = new System.Windows.Forms.Label();
            this.animationEvents = new System.Windows.Forms.Timer(this.components);
            this.backPanel = new System.Windows.Forms.Panel();
            this.frontPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(10, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(253, 56);
            this.label.TabIndex = 0;
            this.label.Text = "Text";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // animationEvents
            // 
            this.animationEvents.Enabled = true;
            this.animationEvents.Interval = 16;
            this.animationEvents.Tick += new System.EventHandler(this.animationEvents_Tick);
            // 
            // backPanel
            // 
            this.backPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.backPanel.Location = new System.Drawing.Point(269, 3);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(53, 53);
            this.backPanel.TabIndex = 1;
            this.backPanel.Click += new System.EventHandler(this.backPanel_Click);
            // 
            // frontPanel
            // 
            this.frontPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.frontPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(223)))), ((int)(((byte)(112)))));
            this.frontPanel.Location = new System.Drawing.Point(269, 3);
            this.frontPanel.Name = "frontPanel";
            this.frontPanel.Size = new System.Drawing.Size(0, 53);
            this.frontPanel.TabIndex = 2;
            this.frontPanel.Click += new System.EventHandler(this.frontPanel_Click);
            // 
            // Switch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.frontPanel);
            this.Controls.Add(this.backPanel);
            this.Controls.Add(this.label);
            this.Name = "Switch";
            this.Size = new System.Drawing.Size(325, 59);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Timer animationEvents;
        private System.Windows.Forms.Panel backPanel;
        private System.Windows.Forms.Panel frontPanel;
    }
}
