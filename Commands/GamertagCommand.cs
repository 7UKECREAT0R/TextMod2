using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace TextMod_2.Commands
{
    class GamertagCommand : Command
    {
        private static readonly char[] alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        private static readonly char[] gtag = "A8CD3F6H1JK7MN0PQR5TUVWXYZA8CD3F6H1JK7MN0PQR5TUVWXYZI2E4SGLB9O".ToCharArray();

        public GamertagCommand()
        {
            name = "Gamertag";
            desc = "Makes text look like it just became a 2010 username.";
            category = CommandCategory.MAIN;
        }
        public override string Run(string arguments)
        {
            if (arguments == null)
                return null;
            return TextModCore.MapChars(arguments, alphabet, gtag);
        }
    }
}
