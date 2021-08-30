using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace TextMod_2.Styling
{
    /// <summary>
    /// Load and manage the fonts in memory.
    /// </summary>
    class FontLoader
    {
        public const string BEBAS = "Bebas";

        PrivateFontCollection fonts;

        /// <summary>
        /// Create a new FontLoader.
        /// </summary>
        public FontLoader()
        {
            fonts = new PrivateFontCollection();
            LoadFont(Properties.Resources.Bebas_Regular);
        }
        /// <summary>
        /// Load a font from a forms resource.
        /// </summary>
        /// <param name="resource"></param>
        public void LoadFont(byte[] resource)
        {
            int len = resource.Length;
            uint _ = 0;

            // Allocate memory for the new font and register it.
            IntPtr location = Marshal.AllocCoTaskMem(len);
            Marshal.Copy(resource, 0, location, len);
            AddFontMemResourceEx(location, (uint)len, IntPtr.Zero, ref _);
            fonts.AddMemoryFont(location, len);
            Marshal.FreeCoTaskMem(location);
        }
        public Font CreateFont(string fontName, float emSize = 16.0f, FontStyle style = FontStyle.Regular)
        {
            if (fontName == null) return null;
            if (emSize < 1) return null;

            return new Font(fonts.Families.FirstOrDefault(ff => ff.Name.Equals(fontName)), emSize, style);
        }
        public void BindFont(ref Label target, string fontName)
        {
            Font cur = target.Font;
            float size = cur.Size;
            FontStyle style = cur.Style;

            Font nFont = CreateFont(fontName, size, style);
            if(nFont != null)
            {
                cur.Dispose();
                target.Font = nFont;
            }
        }
        public void BindFont(ref Button target, string fontName)
        {
            Font cur = target.Font;
            float size = cur.Size;
            FontStyle style = cur.Style;

            Font nFont = CreateFont(fontName, size, style);
            if (nFont != null)
            {
                cur.Dispose();
                target.Font = nFont;
            }
        }
        public void BindFont(ref TextBox target, string fontName)
        {
            Font cur = target.Font;
            float size = cur.Size;
            FontStyle style = cur.Style;

            Font nFont = CreateFont(fontName, size, style);
            if (nFont != null)
            {
                cur.Dispose();
                target.Font = nFont;
            }
        }
        public void BindFont(ref ListView target, string fontName)
        {
            Font cur = target.Font;
            float size = cur.Size;
            FontStyle style = cur.Style;

            Font nFont = CreateFont(fontName, size, style);
            if (nFont != null)
            {
                cur.Dispose();
                target.Font = nFont;
            }
        }

        // Win32

        [DllImport("gdi32.dll")]
        public static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
    }
}
