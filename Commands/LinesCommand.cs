using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace TextMod_2.Commands
{
    class LinesCommand : Command
    {
        public LinesCommand()
        {
            name = "Lines";
            desc = "Puts each word on a separate line.";
            category = CommandCategory.MAIN;
        }
        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;

            return arguments.Replace(' ', '\n');
        }
    }
}
