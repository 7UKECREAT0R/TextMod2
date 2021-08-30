using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMod_2.Core
{
    public abstract class Command
    {
        protected CommandCategory category = CommandCategory.MAIN;
        protected string name;
        protected string desc;

        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="arguments">The remainder text specified.</param>
        /// <returns>Null if an action was already taken. The text to replace to if otherwise.</returns>
        public abstract string Run(string arguments);
        public string Usage
        {
            get
            {
                return TextModCore.PREFIX + name.ToLower();
            }
        }
        public string DictName
        {
            get
            {
                return name.ToUpper();
            }
        }
        public string Name
        {
            get { return name; }
        }
        public string Description
        {
            get { return desc; }
        }
        public CommandCategory Category
        {
            get { return category; }
        }
    }
    public enum CommandCategory
    {
        MAIN, IMAGE, OTHER
    }
}
