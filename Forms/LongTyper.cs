using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextMod_2.Core;
using TextMod_2.Styling;

namespace TextMod_2.Forms
{
    public partial class LongTyper : Form
    {
        static bool typed = false;
        static long waitedMs;
        static long attackMs;
        static string attackString;
        static int typedCharacters = 0;

        static readonly int intervalMs = 250;
        static readonly char[] typeThese = "qwertyuiopasdfghjklzxcvbnm".ToCharArray();
        static readonly Random typeRandom = new Random();

        TextModCore core;
        System.Timers.Timer timer;
        enum TimeUnit : int
        {
            SECONDS = 1000,
            MINUTES = 60000,
            HOURS = 3600000
        }
        public LongTyper(TextModCore core)
        {
            InitializeComponent();

            Visuals.RoundRegion(this, 20);
            Visuals.MakeHandle(handlePanel, this);

            this.core = core;
            foreach(TimeUnit unit in Enum.GetValues(typeof(TimeUnit)))
                timeUnitCheck.Items.Add(unit);
            timeUnitCheck.SelectedIndex = 0;
        }
        private void LongTyper_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisposeTimer();
        }

        private void DisposeTimer()
        {
            if (timer != null)
            {
                typed = false;
                waitedMs = 0;
                attackMs = 1000;
                attackString = null;
                typedCharacters = 0;

                timer.Stop();
                timer.Elapsed -= Timer_Elapsed;
                timer.Dispose();
                timer = null; // please the gc
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(timeAmount.Text, out int amount))
            {
                MessageBox.Show("Input a valid time.", "TextMod2");
                return;
            }

            string text = messageToSend.Text;
            if(string.IsNullOrWhiteSpace(text))
            {
                if(MessageBox.Show("An empty message will not send anything. Continue?", "TextMod2", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }

            TimeUnit unit = (TimeUnit)timeUnitCheck.SelectedItem;
            long timeMs = amount * ((int)unit);

            DisposeTimer();

            ApplicationHook.SetForegroundWindow(core.mainWindowHWND);

            attackMs = timeMs;
            attackString = text;
            timer = new System.Timers.Timer(intervalMs);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                waitedMs += intervalMs;

                if (waitedMs > attackMs)
                {
                    if (typed)
                        return;
                    typed = true;
                    System.Diagnostics.Debug.WriteLine("\nSending MSG");
                    SendKeys.SendWait("^a" + attackString + "{Enter}");
                    (sender as System.Timers.Timer).Stop();
                    return;
                }
                else
                {
                    char c = typeThese[typeRandom.Next(typeThese.Length)];
                    string str = (++typedCharacters % 10 == 0) ? "^a" + c : c.ToString();
                    System.Diagnostics.Debug.Write(str);
                    SendKeys.SendWait(str);
                }
            } catch(Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
