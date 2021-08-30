using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace TextMod_2.Commands
{
    class SoundsCommand : Command
    {
        Dictionary<char, string> sounds;

        public SoundsCommand()
        {
            name = "Sounds";
            desc = "Sounds out each letter. Takes people a while to read it!";
            category = CommandCategory.MAIN;

            sounds = new Dictionary<char, string>();
            sounds.Add('a', "ay");
            sounds.Add('b', "bee");
            sounds.Add('c', "cee");
            sounds.Add('d', "dee");
            sounds.Add('e', "ee");
            sounds.Add('f', "eff");
            sounds.Add('g', "gee");
            sounds.Add('h', "aych");
            sounds.Add('i', "eye");
            sounds.Add('j', "jay");
            sounds.Add('k', "kay");
            sounds.Add('l', "el");
            sounds.Add('m', "em");
            sounds.Add('n', "en");
            sounds.Add('o', "oh");
            sounds.Add('p', "pee");
            sounds.Add('q', "cew");
            sounds.Add('r', "are");
            sounds.Add('s', "ess");
            sounds.Add('t', "tee");
            sounds.Add('u', "you");
            sounds.Add('v', "vee");
            sounds.Add('w', "doubleu");
            sounds.Add('x', "ecks");
            sounds.Add('y', "why");
            sounds.Add('z', "zee");
        }
        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;

            string[] all = new string[arguments.Length];
            for(int i = 0; i < arguments.Length; i++)
            {
                char c = arguments[i];
                if(c == ' ')
                {
                    all[i] = "   ";
                    continue;
                }
                c = char.ToLower(c);
                if (sounds.TryGetValue(c, out string value))
                    all[i] = value;
                else
                    all[i] = "";
            }

            return string.Join(" ", all);
        }
    }
}
