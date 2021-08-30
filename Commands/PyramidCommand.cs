using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace TextMod_2.Commands
{
    class PyramidCommand : Command
    {
        public PyramidCommand()
        {
            name = "Pyramid";
            desc = "Create a pyramid of your text! (warning: very spammy)";
            category = CommandCategory.MAIN;
        }
        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < arguments.Length; i++)
            {
                string sub = arguments.Substring(0, i);
                if (sub.EndsWith(" ")) { continue; }
                sb.Append(sub + "\n");
            }
            for (int i = arguments.Length; i >= 0; i--)
            {
                string sub = arguments.Substring(0, i);
                if (sub.EndsWith(" ")) { continue; }
                sb.Append(sub + "\n");
            }
            return sb.ToString();
        }
    }
}
