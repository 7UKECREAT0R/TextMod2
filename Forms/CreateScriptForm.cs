using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextMod_2.Core;
using TextMod_2.Styling;

namespace TextMod_2.Forms
{
    public partial class CreateScriptForm : Form
    {
        static readonly char[] INVALID = Path.GetInvalidFileNameChars();
        static readonly string COMMAND_TEMPLATE =
@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace {scriptname}
{
    class {scriptname}Command : Command
    {
        // Define your command details in the constructor.
        public {scriptname}Command()
        {
            name = ""{scriptname}"";
            desc = ""The description of this command."";
        }
        
        // Run your code here. 'arguments' is the text passed into
        // the command (excluding the first part) and you can return
        // the string you want to be sent in Discord. If you return
        // null, nothing will be sent in Discord.
        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;
            
        }
        
        // TextMod built-in methods:
        
        // FUNCTION                  SIGNATURE                                   TIME TO EXECUTE
        // Send a message:           ApplicationHook.SendMessage(string text)    [60ms - 400ms]
        // Edit last sent message:   ApplicationHook.EditMessage(string text)    [80ms - 450ms]
        // Delete last sent message: ApplicationHook.DeleteMessage()             [120ms - 550ms]
        // Sleep for x milliseconds: ApplicationHook.Sleep(int ms)               [Nms - 3Nms]
    }
}";
        static readonly string RPV_TEMPLATE =
@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Variables;

namespace {scriptname}
{
    class {scriptname}Variable : RichPresenceVariable
    {
        // Define the details of your variable here.
        // extraArgument is a string that if specified, will be shown
        // in the help menu and requires an argument to be passed.
        public {scriptname}Variable()
        {
            name = ""variable_name"";
            desc = ""The awesome description of your variable!"";
            extraArgument = null;
        }
        
        // This method is called every 2 seconds and should return the
        // text that you want to be shown in place of your variable.
        public override string GetString(string argument)
        {
            if(extraArgument != null && argument == null)
                return ""needs argument"";
            
        }
        
        // If you allocated anything that needs to be disposed, do it here.
        public override void Dispose()
        {
            return;
        }
    }
}";

        public CreateScriptForm()
        {
            InitializeComponent();
            Visuals.MakeHandle(dragPanel, this);
            Visuals.MakeHandle(label1, this);
            Visuals.RoundRegion(this, 5);
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = nameTextBox.Text;
            if(text.Any(c => INVALID.Contains(c)))
            {
                text = new string(text.Where(c => !INVALID.Contains(c)).ToArray());
                nameTextBox.Text = text;
                nameTextBox.SelectionStart = text.Length;
            }

            bool empty = string.IsNullOrWhiteSpace(text);
            createCommandButton.Enabled = !empty;
            createRPVButton.Enabled = !empty;
        }
        private void folderButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", TextModCore.DIR_SCRIPTS);
        }

        private void createCommandButton_Click(object sender, EventArgs e)
        {
            string text = nameTextBox.Text;
            if (text.Any(c => INVALID.Contains(c)))
            {
                MessageBox.Show("Invalid characters in the script name. (this error shouldn't happen)");
                return;
            }
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Script name cannot be empty. (this error shouldn't happen)");
                return;
            }
            string path = Path.Combine(TextModCore.DIR_SCRIPTS, Path.GetFileNameWithoutExtension(text) + ".cs");
            string content = COMMAND_TEMPLATE.Replace("{scriptname}", text);
            File.WriteAllText(path, content);

            nameTextBox.Text = "";
            createCommandButton.Enabled = false;
            createRPVButton.Enabled = false;
        }
        private void createRPVButton_Click(object sender, EventArgs e)
        {
            string text = nameTextBox.Text;
            if (text.Any(c => INVALID.Contains(c)))
            {
                MessageBox.Show("Invalid characters in the script name. (this error shouldn't happen)");
                return;
            }
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Script name cannot be empty. (this error shouldn't happen)");
                return;
            }
            string path = Path.Combine(TextModCore.DIR_SCRIPTS, Path.GetFileNameWithoutExtension(text) + ".cs");
            string content = RPV_TEMPLATE.Replace("{scriptname}", text);
            File.WriteAllText(path, content);

            nameTextBox.Text = "";
            createCommandButton.Enabled = false;
            createRPVButton.Enabled = false;
        }
    }
}