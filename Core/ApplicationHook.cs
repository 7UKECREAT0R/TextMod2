using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;

namespace TextMod_2.Core
{
    /// <summary>
    /// 
    /// SORTA OBSOLETE - WAS BROKEN IN A DISCORD UPDATE
    /// 
    /// Handles all the events related to focused fields and getting Discord input.
    /// This also has failsafe methods after the patch to use, however they don't work as well.
    /// </summary>
    static class ApplicationHook
    {
        static AutomationElement FOCUS;
        static ControlType FOCUS_TYPE;
        static ValuePattern FOCUS_VALUE; // null usually
        static string FOCUS_NAME;
        static int FOCUS_PID;

        /// <summary>
        /// Set to true when Hook() is called.
        /// Determines if the new enter/automation method is used.
        /// If false then F12 and the legacy text method are used.
        /// </summary>
        public static bool HOOKED = false;

        /// <summary>
        /// Hook all the events required for the InputHandler.
        /// </summary>
        public static void Hook()
        {
            if (HOOKED) return;
            Automation.AddAutomationFocusChangedEventHandler(FocusChangeEvent);
            Application.ApplicationExit += UnhookInputHandler;
            HOOKED = true;
            Debug.WriteLine("Successfully started ApplicationHook.");
        }
        /// <summary>
        /// Returns if the specified application is the currently focused one.
        /// </summary>
        /// <param name="testPID"></param>
        /// <returns></returns>
        public static bool ApplicationFocused(int testPID)
        {
            if(HOOKED)
                return FOCUS_PID == testPID;
            else
            {
                IntPtr focus = GetForegroundWindow();
                GetWindowThreadProcessId(focus, out int current);
                return current == testPID;
            }
        }
        public static bool IsEditField()
        {
            if (FOCUS_TYPE == null)
                return false;
            return FOCUS_TYPE.Id == ControlType.Edit.Id;
        }
        /// <summary>
        /// Get the text in the currently focused textbox.
        /// </summary>
        /// <returns></returns>
        public static string GetText()
        {
            if (HOOKED)
            {
                if (FOCUS_TYPE == null || FOCUS_TYPE.Id != ControlType.Edit.Id || FOCUS_VALUE == null)
                    return null;
                string value = FOCUS_VALUE.Current.Value;
                return value;
            } else
            {
                // fallback (used because automation got dead)
                IDataObject old = Clipboard.GetDataObject();
                SendKeys.SendWait("^a^c");
                Thread.Sleep(TextModCore.performanceMode ? 100 : 25);
                IDataObject fresh = Clipboard.GetDataObject();
                if (old == fresh)
                    return null;
                if (fresh.GetFormats().Contains(DataFormats.Text))
                    return (string)fresh.GetData(DataFormats.Text);
                else if (fresh.GetFormats().Contains(DataFormats.UnicodeText))
                    return (string)fresh.GetData(DataFormats.UnicodeText);
                Clipboard.SetDataObject(old, true, 3, 50);
                return null;
            }
        }
        /// <summary>
        /// Set the text in the currently focused textbox.
        /// </summary>
        /// <param name="text"></param>
        public static void SetText(string text)
        {
            if (!HOOKED || FOCUS_TYPE == null || FOCUS_TYPE.Id != ControlType.Edit.Id || FOCUS_VALUE == null)
                return;

            if (!FOCUS_VALUE.Current.IsReadOnly && FOCUS.Current.IsEnabled)
                FOCUS_VALUE.SetValue(text);
            else return;
        }

        // TextMod API

        /// <summary>
        /// Simulate sending keypresses in Discord to send a message.
        /// </summary>
        /// <param name="text"></param>
        public static void SendMessage(string text)
        {
            if (text == null)
                return;

            Clipboard.SetText(text);
            Thread.Sleep(TextModCore.performanceMode ? 200 : 30);
            if (HOOKED)
                SendKeys.SendWait("^a{Backspace}^v");
            else
                SendKeys.SendWait("^a^v");
            Thread.Sleep(TextModCore.performanceMode ? 200 : 30);
            if (!HOOKED)
                SendKeys.SendWait("{Enter}");
        }
        /// <summary>
        /// Simulate sending keypresses in Discord to edit the last sent message.
        /// </summary>
        /// <param name="text"></param>
        public static void EditMessage(string text)
        {
            if (text == null)
                return;

            SendKeys.SendWait("{Up}");
            Clipboard.SetText(text);
            Thread.Sleep(TextModCore.performanceMode ? 250 : 50);
            if (HOOKED)
                SendKeys.SendWait("^a{Backspace}^v");
            else
                SendKeys.SendWait("^a^v");
            Thread.Sleep(TextModCore.performanceMode ? 200 : 30);
            if (!HOOKED)
                SendKeys.SendWait("{Enter}");
        }
        /// <summary>
        /// Delete the last sent message by the user.
        /// </summary>
        public static void DeleteMessage()
        {
            SendKeys.SendWait("{Up}");
            Thread.Sleep(TextModCore.performanceMode ? 250 : 50);
            SendKeys.SendWait("^a{Backspace}");
            Thread.Sleep(TextModCore.performanceMode ? 100 : 20);
            SendKeys.SendWait("{Enter}");
            Thread.Sleep(TextModCore.performanceMode ? 200 : 50);
            SendKeys.SendWait("{Enter}");
        }
        /// <summary>
        /// Wait for a certain amount of time. Similar to Thread.Sleep, however this one respects performanceMode.
        /// </summary>
        public static void Sleep(int milliseconds)
        {
            if (milliseconds <= 0)
                return;

            long result = TextModCore.performanceMode ? milliseconds * 3 : milliseconds;
            if (result > int.MaxValue)
                milliseconds = int.MaxValue;
            else milliseconds = (int)result;
            Thread.Sleep(milliseconds);
        }

        private static void FocusChangeEvent(object sender, AutomationFocusChangedEventArgs e)
        {
            // So it only requires one access since UIAutomation is slow as FRICK.
            AutomationElement current = sender as AutomationElement;
            FOCUS = current;
            FOCUS_TYPE = current.Current.ControlType;
            FOCUS_NAME = current.Current.Name;
            FOCUS_PID = current.Current.ProcessId;

            try
            {
                if (FOCUS_TYPE.Id == ControlType.Edit.Id)
                    FOCUS_VALUE = current.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                else
                    FOCUS_VALUE = null;
            } catch(InvalidOperationException)
            {
                FOCUS_VALUE = null;
            } catch(ElementNotAvailableException)
            {
                FOCUS_VALUE = null;
            }
        }

        private static void UnhookInputHandler(object sender, EventArgs e)
        {
            Automation.RemoveAutomationFocusChangedEventHandler(FocusChangeEvent);
            Application.ApplicationExit -= UnhookInputHandler;
        }
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32")]
        static extern int GetWindowThreadProcessId(IntPtr hWnd, out int processId);
    }
}