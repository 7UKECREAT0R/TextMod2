using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace TextMod_2.Commands
{
    class NatoCommand : Command
    {
        Dictionary<char, string> nato;

        public NatoCommand()
        {
            name = "NATO";
            desc = "Converts letters to phonetics.";
            category = CommandCategory.MAIN;

            nato = new Dictionary<char, string>();
            nato.Add('a', "Alfa");
            nato.Add('b', "Bravo");
            nato.Add('c', "Charlie");
            nato.Add('d', "Delta");
            nato.Add('e', "Echo");
            nato.Add('f', "Foxtrot");
            nato.Add('g', "Golf");
            nato.Add('h', "Hotel");
            nato.Add('i', "India");
            nato.Add('j', "Juliett");
            nato.Add('k', "Kilo");
            nato.Add('l', "Lima");
            nato.Add('m', "Mike");
            nato.Add('n', "November");
            nato.Add('o', "Oscar");
            nato.Add('p', "Papa");
            nato.Add('q', "Quebec");
            nato.Add('r', "Romeo");
            nato.Add('s', "Sierra");
            nato.Add('t', "Tango");
            nato.Add('u', "Uniform");
            nato.Add('v', "Victor");
            nato.Add('w', "Whiskey");
            nato.Add('x', "Xray");
            nato.Add('y', "Yankee");
            nato.Add('z', "Zulu");
        }
        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;

            string[] all = new string[arguments.Length];
            for (int i = 0; i < arguments.Length; i++)
            {
                char c = arguments[i];
                if (c == ' ')
                {
                    all[i] = "   ";
                    continue;
                }
                c = char.ToLower(c);
                if (nato.TryGetValue(c, out string value))
                    all[i] = value;
                else
                    all[i] = "";
            }

            return string.Join(" ", all);
        }
    }
}
