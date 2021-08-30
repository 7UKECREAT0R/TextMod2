using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextMod_2.Forms.Art
{
    public partial class AsciiArtText : Form
    {
        public const char SPACE = ' ';
        public const char BLOCK = '█';
        public const int WIDTH = 80;
        public const int HEIGHT = 25;

        Size charSize;
        char brush = BLOCK;
        char[,] grid = new char[WIDTH, HEIGHT];

        void Clear()
        {
            for (int x = 0; x < WIDTH; x++)
            {
                for (int y = 0; y < HEIGHT; y++)
                {
                    grid[x, y] = SPACE;
                }
            }
            UpdateDisplay();
        }
        string[] BuildLines()
        {
            char[] buffer = new char[WIDTH];
            string[] lines = new string[HEIGHT];
            for (int line = 0; line < HEIGHT; line++)
            {
                for (int x = 0; x < WIDTH; x++)
                    buffer[x] = grid[x, line];
                lines[line] = new string(buffer);
            }
            return lines;
        }
        void UpdateDisplay()
        {
            string[] lines = BuildLines();
            display.Text = string.Join("\n", lines);
        }
        public AsciiArtText()
        {
            InitializeComponent();
            Clear();
        }
        private void AsciiArtText_Load(object sender, EventArgs e)
        {
            charSize = TextRenderer.MeasureText(BLOCK.ToString(), display.Font);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }
        /// <summary>
        /// the ultimate inline code.
        /// </summary>
        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(("```" + string.Join("\n", BuildLines())).Substring(0, 1997) + "```");
        }

        bool mouseDown = false;
        private void display_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }
        private void display_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void display_MouseLeave(object sender, EventArgs e)
        {
            mouseDown = false;
        }

        private void display_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseDown)
                return;

            Point position = e.Location;
            position.X /= (charSize.Height / 2);
            position.Y /= (charSize.Height);

            if (position.X >= WIDTH)
                position.X = WIDTH - 1;
            if (position.X < 0)
                position.X = 0;
            if (position.Y >= HEIGHT)
                position.Y = HEIGHT - 1;
            if (position.Y < 0)
                position.Y = 0;

            if (e.Button == MouseButtons.Left)
                grid[position.X, position.Y] = brush;
            else if(e.Button == MouseButtons.Right)
                grid[position.X, position.Y] = SPACE;
            UpdateDisplay();
        }
    }
}
