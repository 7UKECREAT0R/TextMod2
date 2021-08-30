using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TextMod_2.Variables
{
    class ActiveVariable : RichPresenceVariable
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        static Process GetActiveProcess()
        {
            IntPtr hWnd = GetForegroundWindow();
            GetWindowThreadProcessId(hWnd, out uint pid);
            return Process.GetProcessById((int)pid);
        }

        public ActiveVariable()
        {
            name = "active";
            desc = "The name of the active application. Not privacy intrusive.";
            extraArgument = null;
        }
        public override string GetString(string argument)
        {
            Process activeProcess = GetActiveProcess();
            return activeProcess.ProcessName;
        }
        public override void Dispose()
        {
            return;
        }
    }
}
