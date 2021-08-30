using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextMod_2.Core;

namespace TextMod_2.Commands
{
    class SnippetCommand : Command
    {

        public SnippetCommand()
        {
            name = "Snippet";
            desc = "Send the contents of a text file in \"TextMod\\Snippets\".";
            category = CommandCategory.MAIN;
        }
        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;

            string path = Path.Combine(TextModCore.DIR_SNIPPETS, arguments + ".txt");
            if(File.Exists(path))
            {
                string contents = File.ReadAllText(path);
                return contents.Length > 2000 ?
                    contents.Substring(0, 2000) : contents;
            } else {
                var result = MessageBox.Show("Snippet doesn't exist. Do you want to make it?",
                    "TextMod", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return null;

                File.WriteAllText(path, "");
                Process.Start("notepad.exe", path);
            }
            return null;
        }
    }
}