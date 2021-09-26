using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextMod_2
{
    static class Program
    {
        public const string VERSION_FILE = "current-version.txt";
        static string currentVersion = null;

        public static int CurrentVersion
        {
            get
            {
                if (currentVersion == null)
                    currentVersion = System.IO.File.ReadAllText(VERSION_FILE).Trim('\n', '\f', '\t').Trim();
                return int.Parse(currentVersion);
            }
        }
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // this is without splash:
            // Application.Run(new Form1());

            // new one is here:
            var splash = new SplashScreen();
            splash.Run(Environment.GetCommandLineArgs());
        }
    }
}
