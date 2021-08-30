using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMod_2.Variables
{
    /// <summary>
    /// A variable replaced in Rich Presence.
    /// </summary>
    public abstract class RichPresenceVariable : IDisposable
    {
        public string name;
        public string desc;

        public string extraArgument = null;
        public string Usage
        {
            get
            {
                if(extraArgument == null)
                    return "{" + name.ToLower() + "}";
                else
                    return "{" + name.Replace(":", "").ToLower() + ": " + extraArgument + "}";
            }
        }

        /// <summary>
        /// Get the string to replace the variable.
        /// </summary>
        /// <param name="argument">The argument passed in. This is always null if extraArgument is defined as null.</param>
        /// <returns>The string to replace the variable with.</returns>
        public abstract string GetString(string argument);
        public abstract void Dispose();
    }
}