using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextMod_2
{
    static class Program
    {
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
