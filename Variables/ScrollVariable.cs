using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMod_2.Variables
{
    class ScrollVariable : RichPresenceVariable
    {
        public ScrollVariable()
        {
            name = "scroll";
            desc = "Scroll through some text. This is animated!";
            extraArgument = "any text";
        }

        public string fullString = "";
        public int scrollIndex = 0;

        public string IncrementScroll()
        {
            string trimString = fullString.EndsWith(" ") ? fullString : fullString + " ";

            if (trimString.Length < 2)
                return trimString; // do nothing

            int len = trimString.Length;
            int halfLen = len / 2;
            if (halfLen >= len)
                return trimString;

            scrollIndex++;

            if (scrollIndex >= len)
                scrollIndex = 0;

            int finalIndex = scrollIndex + halfLen;
            int rollover = finalIndex - len;

            if (rollover <= 0)
                return trimString.Substring(scrollIndex, halfLen);
            else
                return trimString.Substring(scrollIndex, len - scrollIndex)
                    + trimString.Substring(0, rollover);
        }

        public override string GetString(string argument)
        {
            if (argument == null)
                return "NO_ARG_GIVEN";

            // Reset if new text was given.
            if(!argument.Equals(fullString))
            {
                fullString = argument;
                scrollIndex = -1;
            }

            return IncrementScroll();
        }
        public override void Dispose()
        {
            return;
        }
    }
}
