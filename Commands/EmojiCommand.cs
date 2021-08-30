using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace TextMod_2.Commands
{
    class EmojiCommand : Command
    {
        public EmojiCommand()
        {
            name = "Emoji";
            desc = "Turn each of your letters into emoji! Makes big text.";
            category = CommandCategory.MAIN;
        }
        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arguments.Length; i++)
            {
                char c = arguments[i];
                if (c == ' ')
                    sb.Append(":blue_square: ");
                else if(TryGetNumberEmoji(c, out string emoji))
                {
                    sb.Append(emoji);
                    sb.Append(' ');
                } else
                {
                    sb.Append(":regional_indicator_");
                    sb.Append(char.ToLower(c));
                    sb.Append(": ");
                }
            }

            string final = sb.ToString().Trim();
            if (string.IsNullOrWhiteSpace(final))
                return null;
            return final;
        }
        private bool TryGetNumberEmoji(char c, out string emoji)
        {
            switch(c)
            {
                case '0':
                    emoji = ":zero:";
                    return true;
                case '1':
                    emoji = ":one:";
                    return true;
                case '2':
                    emoji = ":two:";
                    return true;
                case '3':
                    emoji = ":three:";
                    return true;
                case '4':
                    emoji = ":four:";
                    return true;
                case '5':
                    emoji = ":five:";
                    return true;
                case '6':
                    emoji = ":six:";
                    return true;
                case '7':
                    emoji = ":seven:";
                    return true;
                case '8':
                    emoji = ":eight:";
                    return true;
                case '9':
                    emoji = ":nine:";
                    return true;
                default:
                    emoji = null;
                    return false;
            }
        }
    }
}
