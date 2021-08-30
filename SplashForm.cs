using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextMod_2
{
    public partial class SplashForm : Form
    {
        System.Threading.Timer timer;
        public static string STATUS = "";
        public SplashForm()
        {
            InitializeComponent();
            timer = new System.Threading.Timer(QueryStatus, this, 1000, 32);
        }
        private void SplashForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Dispose();
        }
        private void QueryStatus(object state)
        {
            SplashForm self = state as SplashForm;
            if (self.label1.Text.Equals(STATUS))
                return;

            MethodInvoker invoke = delegate ()
            {
                self.label1.Text = STATUS;
            };

            try
            {
                self.Invoke(invoke, state);
            }
            catch (Exception)
            {
                timer.Dispose();
            }
        }
    }
}
