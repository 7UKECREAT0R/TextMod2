using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMod_2.Variables
{
    class ChooseVariable : RichPresenceVariable
    {
        Random random = new Random();
        public ChooseVariable()
        {
            name = "choose";
            desc = "Choose a random string of text (separated by commas) every two seconds.";
            extraArgument = "list, of, things";
        }

        public override string GetString(string argument)
        {
            if (string.IsNullOrWhiteSpace(argument))
                return "NO_ARG_GIVEN";

            string[] parts = argument
                .Split(',')
                .Select(s => s.Trim())
                .ToArray();
            return parts[random.Next(parts.Length)];
        }
        public override void Dispose()
        {
            return;
        }
    }
}
