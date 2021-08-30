using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TextMod_2.Variables
{
    class MousePositionVariable : RichPresenceVariable
    {
        public MousePositionVariable()
        {
            name = "mouse";
            desc = "The coordinates of your mouse cursor.";
            extraArgument = null;
        }

        public override string GetString(string argument)
        {
            GetCursorPos(out POINT p);
            return p.X + ", " + p.Y;
        }
        public override void Dispose()
        {
            return;
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out POINT lpPoint);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                X = x;
                Y = y;
            }

            public static implicit operator System.Drawing.Point(POINT p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }

            public static implicit operator POINT(System.Drawing.Point p)
            {
                return new POINT(p.X, p.Y);
            }
        }
    }
}
