using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace TextMod_2.Commands
{
    class UpperCommand : Command
    {
        public UpperCommand()
        {
            name = "Upper";
            desc = "MAKES YOUR TEXT UPPERCASE";
            category = CommandCategory.MAIN;
        }

        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;

            return arguments.ToUpper();
        }
    }
}
