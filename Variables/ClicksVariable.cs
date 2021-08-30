using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMod_2.Core;

namespace TextMod_2.Variables
{
    class ClicksVariable : RichPresenceVariable
    {
        public int clicks = 0;
        public ClicksVariable()
        {
            name = "clicks";
            desc = "Your total amount of clicks since TextMod started!";
            extraArgument = null;

            MouseHook.MouseAction += MouseHook_MouseAction;
            MouseHook.Start();
    }

        private void MouseHook_MouseAction(object sender, EventArgs e)
        {
            clicks++;
        }
        public override string GetString(string argument)
        {
            return clicks.ToString();
        }
        public override void Dispose()
        {
            MouseHook.Stop();
            MouseHook.MouseAction -= MouseHook_MouseAction;
        }
    }
}
