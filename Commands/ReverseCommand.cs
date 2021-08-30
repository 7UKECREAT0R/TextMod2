using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace TextMod_2.Commands
{
    class ReverseCommand : Command
    {
        public ReverseCommand()
        {
            name = "Reverse";
            desc = "Reverses your text. (not gonna put an example of it)";
            category = CommandCategory.MAIN;
        }
        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;

            char[] chars = arguments.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}
