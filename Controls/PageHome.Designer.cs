
namespace TextMod_2.Controls
{
    partial class PageHome
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
            this.switchStartup = new TextMod_2.Controls.Switch();
            this.switchPerformance = new TextMod_2.Controls.Switch();
            this.switchScripting = new TextMod_2.Controls.Switch();
            this.attachButton = new System.Windows.Forms.Button();
            this.hideButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(249)))), ((int)(((byte)(131)))));
            this.label1.Location = new System.Drawing.Point(369, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "WHATS UP";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(317, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(380, 141);
            this.label2.TabIndex = 1;
            this.label2.Text = "Welcome to the TextMod home menu! You can\'t do much here, but you can use the tab" +
    "s on the left to get a little more useful options!";
            // 
            // switchStartup
            // 
            this.switchStartup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.switchStartup.IsChecked = false;
            this.switchStartup.Location = new System.Drawing.Point(345, 292);
            this.switchStartup.Name = "switchStartup";
            this.switchStartup.Size = new System.Drawing.Size(325, 59);
            this.switchStartup.TabIndex = 2;
            this.switchStartup.TitleFont = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.switchStartup.TitleText = "RUN ON STARTUP";
            // 
            // switchPerformance
            // 
            this.switchPerformance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.switchPerformance.IsChecked = false;
            this.switchPerformance.Location = new System.Drawing.Point(345, 357);
            this.switchPerformance.Name = "switchPerformance";
            this.switchPerformance.Size = new System.Drawing.Size(325, 59);
            this.switchPerformance.TabIndex = 2;
            this.switchPerformance.TitleFont = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.switchPerformance.TitleText = "PERFORMANCE MODE";
            // 
            // switchScripting
            // 
            this.switchScripting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.switchScripting.IsChecked = false;
            this.switchScripting.Location = new System.Drawing.Point(345, 422);
            this.switchScripting.Name = "switchScripting";
            this.switchScripting.Size = new System.Drawing.Size(325, 59);
            this.switchScripting.TabIndex = 2;
            this.switchScripting.TitleFont = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.switchScripting.TitleText = "ENABLE SCRIPTING";
            // 
            // attachButton
            // 
            this.attachButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.attachButton.Enabled = false;
            this.attachButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.attachButton.FlatAppearance.BorderSize = 0;
            this.attachButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attachButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.attachButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.attachButton.Location = new System.Drawing.Point(345, 487);
            this.attachButton.Name = "attachButton";
            this.attachButton.Size = new System.Drawing.Size(325, 56);
            this.attachButton.TabIndex = 3;
            this.attachButton.Text = "[!] ATTACH TO DISCORD";
            this.attachButton.UseVisualStyleBackColor = false;
            this.attachButton.Visible = false;
            this.attachButton.Click += new System.EventHandler(this.attachButton_Click);
            // 
            // hideButton
            // 
            this.hideButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.hideButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.hideButton.FlatAppearance.BorderSize = 0;
            this.hideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hideButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.hideButton.ForeColor = System.Drawing.Color.White;
            this.hideButton.Location = new System.Drawing.Point(345, 487);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(325, 56);
            this.hideButton.TabIndex = 4;
            this.hideButton.Text = " HIDE TEXTMOD";
            this.hideButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hideButton.UseVisualStyleBackColor = false;
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            // 
            // PageHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.Controls.Add(this.hideButton);
            this.Controls.Add(this.attachButton);
            this.Controls.Add(this.switchScripting);
            this.Controls.Add(this.switchPerformance);
            this.Controls.Add(this.switchStartup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PageHome";
            this.Size = new System.Drawing.Size(1014, 620);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Switch switchStartup;
        private Switch switchPerformance;
        private Switch switchScripting;
        private System.Windows.Forms.Button attachButton;
        private System.Windows.Forms.Button hideButton;
    }
}
