using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace TextMod_2.Core
{
    /// <summary>
    /// Listens for Enter keypresses to activate TextMod.
    /// </summary>
    class KeyboardHook
    {
        public enum MOD {
            FURRY,          // Furry speak
            ODD,            // Odd Text
            NOBACKSPACE,    // Disallow backspace
            MOUSEKEYS,      // WASD move mouse
            BROKENKEYBOARD, // Cancels keypress randomly
            DOUBLETYPE,     // Keys press twice
        }

        public static bool useKeyboardMod = false;
        public static MOD keyboardMod;

        static bool HOOKED = false;
        [STAThread]
        public static void Hook()
        {
            if (HOOKED) return;
            _keyboardHookID = SetKeyboardHook(_keyboardProc);
            Application.ApplicationExit += UnhookKeyboard;
            HOOKED = true;
            System.Diagnostics.Debug.WriteLine("Successfully started KeyboardHook.");
        }
        [STAThread]
        private static void UnhookKeyboard(object sender, EventArgs e)
        {
            UnhookWindowsHookEx(_keyboardHookID);
            Application.ApplicationExit -= UnhookKeyboard;
        }

        public delegate bool KeyboardCallbackEventHandler(Keys key);
        public static event KeyboardCallbackEventHandler OnKeyboardCallback;

        private static LowLevelKeyboardProc _keyboardProc = KeyboardHookCallback;
        private static IntPtr _keyboardHookID = IntPtr.Zero;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int nVirtKey);

        public static bool IsKeyDown(Keys key)
        {
            return 0 != (GetAsyncKeyState((int)key) & 0x8000);
        }

        public delegate IntPtr LowLevelKeyboardProc
            (int nCode, IntPtr wParam, IntPtr lParam);

        [STAThread]
        private static IntPtr KeyboardHookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if(OnKeyboardCallback == null)
                return CallNextHookEx(_keyboardHookID, nCode, wParam, lParam);
            if (nCode >= 0 && wParam == (IntPtr)0x0100) // https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-keydown
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys k = ((Keys)vkCode);

                try
                {
                    bool doContinue = OnKeyboardCallback.Invoke(k);
                    if (!doContinue)
                        return (IntPtr)12; // any non-zero
                } catch(Exception exc) {
                    Debug.WriteLine("Major exception:\n\n" + exc.ToString());
                }
                return CallNextHookEx(_keyboardHookID, nCode, wParam, lParam);
            }
            return CallNextHookEx(_keyboardHookID, nCode, wParam, lParam);
        }
        private static IntPtr SetKeyboardHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(13, proc, // WH_KEYBOARD_LL
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }
    }
}
