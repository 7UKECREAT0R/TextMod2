using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace TextMod_2.Commands
{
    class LongCommand : Command
    {
        public LongCommand()
        {
            name = "Long";
            desc = "m a k e s   t e x t   l o n g";
            category = CommandCategory.MAIN;
        }
        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;

            char[] chars = arguments.ToCharArray();
            return string.Join(" ", chars);
        }
    }
}
