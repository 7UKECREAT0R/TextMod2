using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace TextMod_2.Commands
{
    class WeirdCommand : Command
    {
        public WeirdCommand()
        {
            name = "Weird";
            desc = "Makes your text just plain weird...";
            category = CommandCategory.MAIN;
        }
        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;

            return arguments.ToLower().Replace("a", "æ").Replace("e", "ḝ").Replace(".", ":")
                .Replace(",", "").Replace("!", "1").Replace("qu", "kw").Replace("i", "į")
                .Replace("o", "ő").Replace("u", "ąǜ").Replace("x", "cks").Replace("p", "Þ")
                .Replace("d", "ď").Replace("f", "Ӻ").Replace("n", "ͷ").Replace("m", "ᵯ")
                .Replace("c", "ɔ").Replace("r", "ř").Replace("t", "ͳ").Replace("?", "¿");
        }
    }
}
