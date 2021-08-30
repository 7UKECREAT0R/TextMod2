using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace TextMod_2.Commands
{
    class BinaryCommand : Command
    {
        public BinaryCommand()
        {
            name = "Binary";
            desc = "Converts text to 0s and 1s.";
            category = CommandCategory.MAIN;
        }
        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;

            char[] chars = arguments.ToCharArray();
            StringBuilder sb = new StringBuilder();
            foreach (char c in chars)
            {
                string cs = Convert.ToString(c, 2).PadLeft(8, '0');
                sb.Append(cs + " ");
            }
            try
            {
                sb.Remove(sb.Length - 1, 1);
            }
            catch (ArgumentOutOfRangeException) { }
            return sb.ToString();
        }
    }
}
