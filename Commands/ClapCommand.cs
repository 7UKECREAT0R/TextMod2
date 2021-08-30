using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace TextMod_2.Commands
{
    class ClapCommand : Command
    {
        public ClapCommand()
        {
            name = "Clap";
            desc = "Puts claps inbetween your words (idk why i made this)";
            category = CommandCategory.MAIN;
        }
        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;
            return arguments.Replace(" ", ":clap:");
        }
    }
}