using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace TextMod_2.Commands
{
    class TinyCommand : Command
    {
        private static readonly char[] alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        private static readonly char[] superscript = "ᵃᵇᶜᵈᵉᶠᵍʰᶦʲᵏˡᵐⁿᵒᵖᵠʳˢᵗᵘᵛʷˣʸᶻᴬᴮᶜᴰᴱᶠᴳᴴᴵᴶᴷᴸᴹᴺᴼᴾᵠᴿˢᵀᵁⱽᵂˣʸᶻ¹²³⁴⁵⁶⁷⁸⁹⁰".ToCharArray();

        public TinyCommand()
        {
            name = "Tiny";
            desc = "Makes your text really small.";
            category = CommandCategory.MAIN;
        }
        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;
            return TextModCore.MapChars(arguments, alphabet, superscript);
        }
    }
}
