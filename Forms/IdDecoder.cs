using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextMod_2.Forms
{
    public partial class IdDecoder : Form
    {
        public const long DISCORD_EPOCH = 1420070400000L;
        public static readonly DateTime EPOCH = new DateTime(1970, 1, 1);

        public IdDecoder()
        {
            InitializeComponent();
        }

        private void decodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                long toDecode = long.Parse(input.Text);
                long ms = (toDecode >> 22) + DISCORD_EPOCH;
                TimeSpan timeSpan = TimeSpan.FromMilliseconds(ms);
                DateTime created = EPOCH + timeSpan;
                outputLabel.Text = created.ToString("g");
            } catch(FormatException)
            {
                MessageBox.Show("Put a valid user ID.");
            }
        }
    }
}
