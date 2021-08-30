using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace TextMod_2.Commands
{
    class FurryCommand: Command
    {
        public FurryCommand()
        {
            name = "Furry";
            desc = "convewts evewything into fuwwy speak uwu";
            category = CommandCategory.MAIN;
        }
        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;

            return arguments
                .Replace('r', 'w').Replace('l', 'w')
                .Replace('R', 'W').Replace('L', 'W')
                .Replace("x", "cks").Replace("X", "CKS");

        }
    }
}
