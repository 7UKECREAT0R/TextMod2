
namespace TextMod_2.Forms
{
    partial class LongTyper
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.messageToSend = new System.Windows.Forms.TextBox();
            this.timeUnitCheck = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timeAmount = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.handlePanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.handlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(86, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "LONG TYPER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(372, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "fakes typing for however long you want then sends a message";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.messageToSend);
            this.panel1.Location = new System.Drawing.Point(44, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 144);
            this.panel1.TabIndex = 1;
            // 
            // messageToSend
            // 
            this.messageToSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.messageToSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageToSend.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageToSend.ForeColor = System.Drawing.Color.White;
            this.messageToSend.Location = new System.Drawing.Point(6, 6);
            this.messageToSend.Margin = new System.Windows.Forms.Padding(6);
            this.messageToSend.Multiline = true;
            this.messageToSend.Name = "messageToSend";
            this.messageToSend.Size = new System.Drawing.Size(297, 132);
            this.messageToSend.TabIndex = 0;
            this.messageToSend.Text = "Message To Send";
            // 
            // timeUnitCheck
            // 
            this.timeUnitCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.timeUnitCheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeUnitCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timeUnitCheck.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeUnitCheck.ForeColor = System.Drawing.Color.White;
            this.timeUnitCheck.FormattingEnabled = true;
            this.timeUnitCheck.Location = new System.Drawing.Point(153, 291);
            this.timeUnitCheck.Name = "timeUnitCheck";
            this.timeUnitCheck.Size = new System.Drawing.Size(200, 33);
            this.timeUnitCheck.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.timeAmount);
            this.panel2.Location = new System.Drawing.Point(44, 291);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(103, 33);
            this.panel2.TabIndex = 3;
            // 
            // timeAmount
            // 
            this.timeAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.timeAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeAmount.ForeColor = System.Drawing.Color.White;
            this.timeAmount.Location = new System.Drawing.Point(6, 7);
            this.timeAmount.Margin = new System.Windows.Forms.Padding(6);
            this.timeAmount.Multiline = true;
            this.timeAmount.Name = "timeAmount";
            this.timeAmount.Size = new System.Drawing.Size(94, 18);
            this.timeAmount.TabIndex = 0;
            this.timeAmount.Text = "30";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(44, 342);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(309, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "START";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // handlePanel
            // 
            this.handlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.handlePanel.Controls.Add(this.closeButton);
            this.handlePanel.Location = new System.Drawing.Point(0, 0);
            this.handlePanel.Margin = new System.Windows.Forms.Padding(0);
            this.handlePanel.Name = "handlePanel";
            this.handlePanel.Size = new System.Drawing.Size(392, 42);
            this.handlePanel.TabIndex = 5;
            // 
            // closeButton
            // 
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(355, 8);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(29, 27);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // LongTyper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(29)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(392, 399);
            this.Controls.Add(this.handlePanel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.timeUnitCheck);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LongTyper";
            this.Text = "LongTyper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LongTyper_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.handlePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox messageToSend;
        private System.Windows.Forms.ComboBox timeUnitCheck;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox timeAmount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel handlePanel;
        private System.Windows.Forms.Button closeButton;
    }
}