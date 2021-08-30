using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace TextMod_2.Commands
{
    class OddCommand: Command
    {
        public OddCommand()
        {
            name = "Odd";
            desc = "oDd TeXt ThAt LoOkS sTuPiD";
            category = CommandCategory.MAIN;
        }
        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;

            char[] characters = new char[arguments.Length];
            for (int i = 0; i < arguments.Length; i++) {
                char c = arguments[i];
                bool lower = (i % 2) == 0;
                characters[i] = lower ? char.ToLower(c) : char.ToUpper(c);
            }
            return new string(characters);
        }
    }
}
