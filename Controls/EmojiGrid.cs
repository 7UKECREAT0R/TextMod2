using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextMod_2.Controls
{
    public partial class EmojiGrid : UserControl
    {
        static readonly int BLOCK_SIZE = 24;
        static readonly int GRID_SIZE = 12;

        EmojiCell[,] grid;

        EmojiCell tool = EmojiCell.BLACK;
        public void SetTool(EmojiCell cell)
        {
            tool = cell;
        }

        public EmojiGrid()
        {
            InitializeComponent();
            grid = new EmojiCell[GRID_SIZE, GRID_SIZE];
            for(int x = 0; x < GRID_SIZE; x++)
            {
                for (int y = 0; y < GRID_SIZE; y++)
                {
                    grid[x, y] = EmojiCell.WHITE;
                }
            }
        }
        public void Clear()
        {
            for (int x = 0; x < GRID_SIZE; x++)
            {
                for (int y = 0; y < GRID_SIZE; y++)
                {
                    grid[x, y] = EmojiCell.WHITE;
                }
            }
            Invalidate();
        }
        public string GetStringForCell(EmojiCell cell)
        {
            switch(cell)
            {
                case EmojiCell.BLACK:
                    return "⬛";
                case EmojiCell.WHITE:
                    return "⬜";
                case EmojiCell.BLUE:
                    return "🟦";
                case EmojiCell.RED:
                    return "🟥";
                case EmojiCell.ORANGE:
                    return "🟧";
                case EmojiCell.PURPLE:
                    return "🟪";
                case EmojiCell.YELLOW:
                    return "🟨";
                case EmojiCell.BROWN:
                    return "🟫";
                case EmojiCell.GREEN:
                    return "🟩";
                default:
                    return "🤔";
            }
        }
        public string GetString()
        {
            int len = GRID_SIZE - 1;
            string[] lines = new string[GRID_SIZE];
            for(int y = 0; y < GRID_SIZE; y++)
            {
                StringBuilder sb = new StringBuilder();
                for (int x = 0; x < GRID_SIZE; x++)
                {
                    string str = GetStringForCell(grid[x, y]);
                    len += str.Length;
                    if (len > 2000)
                        break;
                    sb.Append(str);
                }
                lines[y] = sb.ToString();
            }
            return string.Join("\n", lines);
        }
        public Brush GetColor(EmojiCell cell)
        {
            switch (cell)
            {
                case EmojiCell.BLACK:
                    return Brushes.Black;
                case EmojiCell.WHITE:
                    return Brushes.White;
                case EmojiCell.BLUE:
                    return Brushes.DeepSkyBlue;
                case EmojiCell.RED:
                    return Brushes.Firebrick;
                case EmojiCell.ORANGE:
                    return Brushes.Orange;
                case EmojiCell.PURPLE:
                    return Brushes.MediumPurple;
                case EmojiCell.YELLOW:
                    return Brushes.Gold;
                case EmojiCell.BROWN:
                    return Brushes.SaddleBrown;
                case EmojiCell.GREEN:
                    return Brushes.ForestGreen;
                default:
                    return Brushes.Magenta;
            }
        }
        private void EmojiGrid_Paint(object sender, PaintEventArgs e)
        {
            Graphics draw = e.Graphics;
            for (int x = 0; x < GRID_SIZE; x++)
            {
                for (int y = 0; y < GRID_SIZE; y++)
                {
                    Rectangle rect = new Rectangle(x * BLOCK_SIZE,
                        y * BLOCK_SIZE, BLOCK_SIZE, BLOCK_SIZE);
                    EmojiCell cell = grid[x, y];
                    draw.FillRectangle(GetColor(cell), rect);
                }
            }
        }

        private void EmojiGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseDown)
                return;

            int x = e.X / BLOCK_SIZE;
            int y = e.Y / BLOCK_SIZE;
            if (x > GRID_SIZE - 1)
                x = GRID_SIZE - 1;
            if (y > GRID_SIZE - 1)
                y = GRID_SIZE - 1;
            if (x < 0)
                x = 0;
            if (y < 0)
                y = 0;
            grid[x, y] = tool;
            Invalidate();
        }

        bool mouseDown = false;
        private void EmojiGrid_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            EmojiGrid_MouseMove(sender, e);
        }
        private void EmojiGrid_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void EmojiGrid_MouseLeave(object sender, EventArgs e)
        {
            mouseDown = false;
        }
    }
    public enum EmojiCell
    {
        BLACK,
        WHITE,
        BLUE,
        RED,
        ORANGE,
        PURPLE,
        YELLOW,
        BROWN,
        GREEN
    }
}
