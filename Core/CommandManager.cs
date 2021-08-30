using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextMod_2.Core
{
    /// <summary>
    /// Collects and manages the commands 
    /// </summary>
    public class CommandManager
    {
        public readonly int commandCount;
        Dictionary<string, Command> commands = new Dictionary<string, Command>();

        public Command[] GetCommandsAsArray()
        {
            int count = commands.Count;
            var input = commands.ToArray();
            Command[] output = new Command[count];
            for(int i = 0; i < count; i++)
                output[i] = input[i].Value;
            return output;
        }

        public CommandManager()
        {
            Assembly current = Assembly.GetEntryAssembly();
            Type type = typeof(Command);
            Type[] all = current.GetTypes();
            Type[] allCommandTypes = all
                .Where(t => t.IsSubclassOf(type) && !t.IsAbstract)
                .ToArray();
            commandCount = allCommandTypes.Length;
            foreach(Type commandType in allCommandTypes)
            {
                Command cmd = (Command)Activator
                    .CreateInstance(commandType);
                string key = cmd.DictName;
                commands.Add(key, cmd);
            }
            Debug.WriteLine("Located and instanced {0} commands.", commandCount);
        }
        /// <summary>
        /// Master method. This does everything including image generation commands and emoji.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>True if a command was run.</returns>
        public bool TryExecuteCommand(string input)
        {
            if (input == null) return false;
            if (input.Length < 0) return false;
            input = input.TrimStart(TextModCore.PREFIX);
            string[] words = input.Split(new char[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length < 1) return false;

            string keyword = words[0].ToUpper();
            Command reference;
            if(commands.TryGetValue(keyword, out reference))
            {
                string text;
                int subLength = reference.Name.Length + 1;
                text = (input.Length > subLength) ? input.Substring(subLength) : null;
                string output = reference.Run(text);
                ApplicationHook.SendMessage(output);
                return true;
            }

            Match match = Emoji.REGEX.Match(input);
            if (match != null)
            {
                Group group = match.Groups[1];
                string emojiname = group.Value;
                if(TextModCore.emoji.TryGetEmojiByName(emojiname, out Emoji? e))
                {
                    Emoji emoji = e.Value;
                    using (Image toSend = TextModCore.emoji.GetEmojiImage(emoji))
                    {
                        Clipboard.SetImage(toSend);
                        if (TextModCore.performanceMode)
                        {
                            SendKeys.SendWait("{Backspace}");
                            System.Threading.Thread.Sleep(50);
                            SendKeys.SendWait("^v");
                        } else
                            SendKeys.SendWait("{Backspace}^v");
                        System.Threading.Thread.Sleep(TextModCore.performanceMode ? 100 : 10);
                        SendKeys.SendWait("{Enter}");
                    }
                    return true;
                }
            }
            return false;
        }
    }
}