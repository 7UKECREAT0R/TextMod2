using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextMod_2.Variables;

namespace TextMod_2.Core
{
    /// <summary>
    /// Instance class managing the core of TextMod.
    /// It's the base interface that links the form and the code.
    /// </summary>
    public class TextModCore : IDisposable
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        private const int MOUSEEVENTF_MOVE = 0x1;

        public const string FILE_SETTINGS = "TextMod\\settings.dat";
        public const string FILE_EMOJI = "TextMod\\emoji.dat";
        public const string FILE_RPC = "TextMod\\rpc.dat";
        public const string DIR_SCRIPTS = "TextMod\\Scripts";
        public const string DIR_SNIPPETS = "TextMod\\Snippets";
        public const string FILE_SCRIPTS_RM = "TextMod\\Scripts\\readme.txt";
        public const string FILE_SNIPPETS_RM = "TextMod\\Snippets\\readme.txt";
        public const char PREFIX = '-';

        bool ignoreNextEnter = false;
        int ignoreNextKey = 0;
        bool oddCaps = false;
        Random modRandom = new Random();
        public TextModCore()
        {
            Initialized = false;
            HasHook = false;
        }

        public bool Initialized
        {
            get; private set;
        }
        public bool HasHook
        {
            get; private set;
        }

        // Storage
        public static bool runOnStartup = true;
        public static bool performanceMode = false;
        public static bool scriptingEnabled = false;
        public static EmojiProfile emoji = new EmojiProfile();
        public static RichPresenceProfile richPresence = new RichPresenceProfile();

        public static void CreateDirectories()
        {
            Directory.CreateDirectory("TextMod");
            Directory.CreateDirectory(DIR_SCRIPTS);
            Directory.CreateDirectory(DIR_SNIPPETS);

            if(!File.Exists(FILE_SCRIPTS_RM))
            {
                File.WriteAllText(FILE_SCRIPTS_RM,
@"This is a folder that contains all scripts you intend to be compiled and run every time TextMod starts.
All of them are C# scripts of classes that extend either Core.Command or Variables.RichPresenceVariable.
The templates can be generated from the scripts tab in TextMod itself. When you drag a script/scripts
into the folder that you like, you can restart TextMod to compile and register them.");
            }
            if (!File.Exists(FILE_SNIPPETS_RM))
            {
                File.WriteAllText(FILE_SNIPPETS_RM,
@"This is a folder that contains all of the text snippets you wish for TextMod to use. Make sure they are .txt files!
The contents of the text files will be sent in Discord when running the ""-snippet <filename>"" command.");
            }
        }
        public static void WriteFiles()
        {
            CreateDirectories();
            WriteMainSettings();

            string emojiFile = emoji.GetFileContents();
            File.WriteAllText(FILE_EMOJI, emojiFile);

            string rpcFile = richPresence.GetFileContents();
            File.WriteAllText(FILE_RPC, rpcFile);
        }
        public static void WriteMainSettings()
        {
            CreateDirectories();
            string settingsFile = runOnStartup + ";" + performanceMode + ";" + scriptingEnabled;
            File.WriteAllText(FILE_SETTINGS, settingsFile);
        }
        public static void ReadFiles()
        {
            CreateDirectories();

            if (File.Exists(FILE_SETTINGS))
            {
                string text = File.ReadAllText(FILE_SETTINGS);
                string[] parts = text.Split(';');
                if (parts.Length < 3)
                    return;
                runOnStartup = parts[0].Equals("True");
                performanceMode = parts[1].Equals("True");
                scriptingEnabled = parts[2].Equals("True");
            }
            if(File.Exists(FILE_EMOJI))
            {
                string[] text = File.ReadAllLines(FILE_EMOJI);
                emoji.ParseFileContents(text);
            }
            if(File.Exists(FILE_RPC))
            {
                string text = File.ReadAllText(FILE_RPC);
                richPresence.ParseFileContents(text);
            }
        }

        ParameterizedThreadStart threadStart;
        Thread commandsThread = null;
        public CommandManager commands { get; private set; }
        public ScriptManager scripts { get; private set; }
        public int processID = -1;
        public IntPtr mainWindowHWND;

        public void Initialize()
        {
            if (Initialized)
            {
                MessageBox.Show("Already Initialized.");
                return;
            }

            SplashForm.STATUS = "Looking for Discord window...";
            LocateDiscordProcess();

            SplashForm.STATUS = "Enabling keyboard hook...";
            KeyboardHook.Hook();
            KeyboardHook.OnKeyboardCallback += OnKeyPressedGlobal;

            SplashForm.STATUS = "Collect commands...";
            commands = new CommandManager();
            scripts = new ScriptManager();

            SplashForm.STATUS = "Create command thread...";
            threadStart = new ParameterizedThreadStart(CommandsThreadStart);

            SplashForm.STATUS = "Load settings...";
            ReadFiles();

            if (scriptingEnabled)
            {
                SplashForm.STATUS = "Collect script files...";
                scripts.LoadScriptFiles(DIR_SCRIPTS);
                SplashForm.STATUS = "Compile scripts...";
                scripts.CompileScripts();

                Script[] allScripts = scripts.scripts;
                foreach(Script script in allScripts)
                {
                    if(script.compiledVariables != null)
                        RichPresenceProfile.VARIABLES.AddRange
                            (script.compiledVariables.Where(cmpv => cmpv != null));
                }
            }

            Initialized = true;
        }
        public void Dispose()
        {
            WriteFiles();
            KeyboardHook.OnKeyboardCallback -= OnKeyPressedGlobal;
            commandsThread?.Abort();
            
            foreach(RichPresenceVariable rpc in RichPresenceProfile.VARIABLES)
            {
                rpc.Dispose();
            }
        }
        public void LocateDiscordProcess()
        {
            Debug.WriteLine("Searching for all Discord processes...");
            Process[] discords = Process.GetProcessesByName("Discord");
            if (discords.Length < 1)
                discords = Process.GetProcessesByName("DiscordCanary");
            if (discords.Length < 1)
                discords = Process.GetProcessesByName("DiscordPTB");
            Debug.WriteLine("Found {0} Discord processes.", discords.Length);

            if (discords.Length < 1)
                return;

            Debug.WriteLine("Searching for main window handle...");
            foreach (Process prs in discords)
                if (prs.MainWindowHandle != IntPtr.Zero)
                {
                    mainWindowHWND = prs.MainWindowHandle;
                    processID = prs.Id;
                }

            if (mainWindowHWND == IntPtr.Zero)
                return;

            Debug.WriteLine("Located window handle {0} with PID {1}", mainWindowHWND, processID);
        }

        /// <summary>
        /// Returns if should continue hook chain.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private bool OnKeyPressedGlobal(Keys key)
        {
            if (ignoreNextEnter && key == Keys.Enter)
            {
                ignoreNextEnter = false;
                return true;
            }
            if(ignoreNextKey > 0)
            {
                ignoreNextKey--;
                return true;
            }

            if (key != (ApplicationHook.HOOKED ? Keys.Enter : Keys.F12))
            {
                if (KeyboardHook.useKeyboardMod)
                {
                    KeyboardHook.MOD mod = KeyboardHook.keyboardMod;
                    int press;
                    switch (mod)
                    {
                        case KeyboardHook.MOD.FURRY:
                            if (key == Keys.R || key == Keys.L)
                            {
                                ignoreNextKey = 1;
                                SendKeys.SendWait("w");
                                return false;
                            }
                            break;
                        case KeyboardHook.MOD.ODD:
                            press = (int)key;
                            if (press >= (int)Keys.A && press <= (int)Keys.Z)
                            {
                                ignoreNextKey = 2;
                                string convert = key.ToString().ToLower();
                                if ((oddCaps = !oddCaps))
                                    convert = convert.ToUpper();
                                SendKeys.SendWait(convert);
                                return false;
                            }
                            break;
                        case KeyboardHook.MOD.NOBACKSPACE:
                            if (key == Keys.Back)
                                return false;
                            break;
                        case KeyboardHook.MOD.MOUSEKEYS:
                            if ((37 > (int)key || (int)key > 40) && key != Keys.Enter && key != Keys.RShiftKey)
                                break;
                            uint X = 0;
                            uint Y = 0;
                            const int amount = 20;
                            if (key == Keys.Left)
                                X -= amount;
                            if (key == Keys.Right)
                                X += amount;
                            if (key == Keys.Up)
                                Y -= amount;
                            if (key == Keys.Down)
                                Y += amount;
                            if(key == Keys.Enter)
                            {
                                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
                            }
                            else if (key == Keys.RShiftKey)
                            {
                                mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
                            }
                            else
                            {
                                mouse_event(MOUSEEVENTF_MOVE, X, Y, 0, 0);
                            }
                            return false;
                        case KeyboardHook.MOD.BROKENKEYBOARD:
                            if (modRandom.Next(3) == 0)
                                return false;
                            else return true;
                        case KeyboardHook.MOD.DOUBLETYPE:
                            press = (int)key;
                            if (press >= (int)Keys.A && press <= (int)Keys.Z)
                            {
                                ignoreNextKey = 1;
                                SendKeys.SendWait(key.ToString().ToLower());
                                return true;
                            }
                            break;
                        default: break;
                    }
                    return true;
                }
                else return true;
            }
            if (!Initialized) return true;
            if (!ApplicationHook.ApplicationFocused(processID)) return true;
            
            //if (!ApplicationHook.IsEditField()) return true;  OBSOLETE
            if (KeyboardHook.IsKeyDown(Keys.LShiftKey)
                || KeyboardHook.IsKeyDown(Keys.RShiftKey)) return true;

            if (ApplicationHook.HOOKED)
            {
                if (commandsThread != null)
                    commandsThread.Abort();

                commandsThread = new Thread(threadStart);
                commandsThread.SetApartmentState(ApartmentState.STA);
                commandsThread.Start(commands);
            }
            else
            {
                // no longer using enter sooo
                string text = ApplicationHook.GetText();
                if (commands.TryExecuteCommand(text))
                    return false;
                if (scripts.TryExecuteCommand(text))
                    return false;
            }

            return false;
        }
        private void CommandsThreadStart(object obj)
        {
            CommandManager commands = obj as CommandManager;
            string text = ApplicationHook.GetText();
            commands.TryExecuteCommand(text);
            ignoreNextEnter = true;
            return;
        }

        // mapping n stuff
        public static string MapChars(string str, char[] start, char[] end)
        {
            char[] chars = str.ToCharArray();
            char[] clone = new char[chars.Length];
            List<char> _start = start.ToList();
            int i = -1;
            foreach (char c in chars)
            {
                i++;
                if (start.Contains(c))
                {
                    int index = _start.IndexOf(c);
                    clone[i] = end[index];
                    continue;
                }
                else
                {
                    clone[i] = c;
                    continue;
                }
            }
            return new string(clone);
        }
        public static string MapAppendChars(string str, char[] start, string[] end)
        {
            string[] a = MapCharsToArray(str, start, end);
            string b = str;
            StringBuilder sb = new StringBuilder();
            int i = -1;
            foreach (char c in b)
            {
                i++;
                sb.Append(c + a[i]);
            }
            return sb.ToString();
        }
        public static string[] MapCharsToArray(string str, char[] start, string[] end)
        {
            char[] chars = str.ToCharArray();
            string[] clone = new string[chars.Length];
            List<char> _start = start.ToList();
            int i = -1;
            foreach (char c in chars)
            {
                i++;
                if (start.Contains(c))
                {
                    int index = _start.IndexOf(c);
                    clone[i] = end[index];
                    continue;
                }
                else
                {
                    clone[i] = c.ToString();
                    continue;
                }
            }
            return clone;
        }
    }
    public enum TextModPage : int
    {
        HOME = 0,
        COMMANDS = 1,
        IMAGE_COMMANDS = 2,
        EMOJI = 3,
        SCRIPTING = 4,
        RICH_PRESENCE = 5,
        UTILITIES = 6
    }
}