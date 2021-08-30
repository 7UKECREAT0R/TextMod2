using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextMod_2.Styling;

namespace TextMod_2.Controls
{
    public partial class Switch : UserControl
    {
        readonly int filledWidth;
        const float speed = 0.3f;

        bool isChecked;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                isChecked = value;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TitleText
        {
            get
            {
                return label.Text;
            }
            set
            {
                label.Text = value;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font TitleFont
        {
            get
            {
                return label.Font;
            }
            set
            {
                label.Font = value;
            }
        }

        public delegate void CheckedChangedHandler(bool isChecked);
        public event CheckedChangedHandler OnCheckedChanged;

        public Switch()
        {
            InitializeComponent();
            filledWidth = backPanel.Width;
        }

        private void animationEvents_Tick(object sender, EventArgs e)
        {
            int cbw = frontPanel.Width;
            int cbg = isChecked ? filledWidth + 2 : 0;
            int cbg2 = isChecked ? filledWidth : 0;
            if (Math.Abs(cbg2 - cbw) > 1)
            {
                cbw = Visuals.Interpolate(cbw, cbg, speed);
                frontPanel.Width = cbw;
            } else
            {
                frontPanel.Width = cbg2;
            }
        }

        private void backPanel_Click(object sender, EventArgs e)
        {
            isChecked = true;
            OnCheckedChanged?.Invoke(true);
        }
        private void frontPanel_Click(object sender, EventArgs e)
        {
            isChecked = false;
            OnCheckedChanged?.Invoke(false);
        }
    }
}
