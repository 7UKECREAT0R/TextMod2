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

namespace TextMod_2.Controls
{
    public partial class PageImageCommands : UserControl
    {
        public PageImageCommands()
        {
            InitializeComponent();
        }
        public void SetCommands(CommandManager manager)
        {
            /*Command[] cmds = manager.GetCommandsAsArray()
                .Where(c => c.Category == CommandCategory.IMAGE).ToArray();
            string[] lines = new string[cmds.Length];
            for (int i = 0; i < cmds.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(cmds[i].Usage);
                while (sb.Length < 15)
                    sb.Append(' ');
                sb.Append("| ");
                sb.Append(cmds[i].Description);
                lines[i] = sb.ToString();
            }
            display.Text = string.Join(Environment.NewLine, lines);*/
            display.Text = "Image commands are on the way! (SOME DAY)";
        }

        private void display_Enter(object sender, EventArgs e)
        {
            label1.Focus();
        }
    }
}
