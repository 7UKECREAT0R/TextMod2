using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMod_2
{
    class SplashScreen : WindowsFormsApplicationBase
    {
        protected override void OnCreateMainForm()
        {
            MainForm = new Form1();
        }
        protected override void OnCreateSplashScreen()
        {
            SplashScreen = new SplashForm();
        }
        protected override bool OnInitialize(ReadOnlyCollection<string> commandLineArgs)
        {
            MinimumSplashScreenDisplayTime = 1000;
            return base.OnInitialize(commandLineArgs);
        }
    }
}
