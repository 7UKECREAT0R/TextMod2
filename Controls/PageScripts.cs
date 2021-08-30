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
using TextMod_2.Forms;

namespace TextMod_2.Controls
{
    public partial class PageScripts : UserControl
    {
        public PageScripts()
        {
            InitializeComponent();
        }
        public void SetScripts(ScriptManager scriptManager)
        {
            string[] allPaths = scriptManager.scriptDirectory;
            Script[] scripts = scriptManager.scripts;

            loadedScripts.Items.Clear();

            if (allPaths.Length < 1)
            {
                loadedScripts.Items.Add("No scripts have been loaded yet.");
                return;
            }

            foreach (string filePath in allPaths)
                loadedScripts.Items.Add(filePath);

            List<string> join = new List<string>();
            foreach (Script script in scripts)
                if (script.IsValidCompilation)
                    foreach (Command cmd in script.compiledCommands)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(cmd.Usage);
                        while (sb.Length < 15)
                            sb.Append(' ');
                        sb.Append("| ");
                        sb.Append(cmd.Description);
                        join.Add(sb.ToString());
                    }
            loadedCommands.Text = string.Join("\n", join);
        }
        private void createButton_Click(object sender, EventArgs e)
        {
            CreateScriptForm form = new CreateScriptForm();
            form.FormClosed += CreateScriptForm_Close;
            form.Show();
        }
        private void CreateScriptForm_Close(object sender, FormClosedEventArgs e)
        {
            CreateScriptForm form = sender as CreateScriptForm;
            form.FormClosed -= CreateScriptForm_Close;
            form.Dispose();
        }
        private void loadedScripts_Enter(object sender, EventArgs e)
        {
            label1.Focus();
        }
        private void loadedCommands_Enter(object sender, EventArgs e)
        {
            label1.Focus();
        }
    }
}
