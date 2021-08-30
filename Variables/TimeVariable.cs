using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMod_2.Variables
{
    class TimeVariable : RichPresenceVariable
    {
        public TimeVariable()
        {
            name = "time";
            desc = "The current time in your timezone.";
            extraArgument = null;
        }

        public override string GetString(string argument)
        {
            return DateTime.Now.ToShortTimeString();
        }
        public override void Dispose()
        {
            return;
        }
    }
}
