using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TextMod_2.Variables
{
    class ActiveTitleVariable : RichPresenceVariable
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        static string GetWindowTitle(IntPtr handle)
        {
            try
            {
                const int nc = 256; // read count
                StringBuilder sb = new StringBuilder(nc);

                if (GetWindowText(handle, sb, nc) > 0)
                {
                    string title = sb.ToString();
                    if (title.Contains("Program Manager"))
                    {
                        title = "Desktop";
                    }
                    return title;
                }
                return null;
            }
            catch (Exception)
            {
                return "EXCEPTION";
            }
        }

        public ActiveTitleVariable()
        {
            name = "activetitle";
            desc = "The window title of the active application. Could be privacy intrusive.";
            extraArgument = null;
        }
        public override string GetString(string argument)
        {
            return GetWindowTitle(GetForegroundWindow());
        }

        public override void Dispose()
        {
            return;
        }
    }
}
