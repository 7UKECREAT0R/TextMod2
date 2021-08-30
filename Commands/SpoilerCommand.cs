using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace TextMod_2.Commands
{
    class SpoilerCommand : Command
    {
        public SpoilerCommand()
        {
            name = "Spoiler";
            desc = "Spoiler tags every single letter.";
            category = CommandCategory.MAIN;
        }
        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;

            char[] chars = arguments.ToCharArray();
            string[] clone = new string[chars.Length];
            int i = -1;
            foreach (char c in chars)
            {
                i++;
                clone[i] = "||" + c + "||";
                continue;
            }
            return string.Join("", clone);
        }
    }
}
