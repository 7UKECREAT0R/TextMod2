using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMod_2.Variables
{
    class CPUVariable : RichPresenceVariable
    {
        bool disabled = false;
        PerformanceCounter cpuMeasure;

        public CPUVariable()
        {
            name = "cpu";
            desc = "Your currently used CPU percentage.";
            extraArgument = null;

            try
            {
                cpuMeasure = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            } catch(Exception)
            {
                disabled = true;
                cpuMeasure = null;
            }
        }
        public override string GetString(string argument)
        {
            if (disabled)
                return "NOT_SUPPORTED";

            return ((int)Math.Round(cpuMeasure.NextValue())) + "%";
        }
        public override void Dispose()
        {
            cpuMeasure?.Dispose();
        }
    }
}
