using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextMod_2.Core;
using TextMod_2.Styling;

namespace TextMod_2.Controls
{
    public partial class TextModTab : UserControl
    {
        string title = "UNKNOWN";
        string desc = "I don't know which tab this is.";
        bool selected;
        TextModPage page;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                titleLabel.Text = value;
            }
        }
        public string Description
        {
            get
            {
                return desc;
            }
            set
            {
                desc = value;
                descLabel.Text = value;
            }
        }
        public TextModPage Page
        {
            get
            {
                return page;
            }
            set
            {
                page = value;
            }
        }


        static readonly Color BG_COLOR = Color.FromArgb(32, 32, 32);
        static readonly Color HV_COLOR = Color.FromArgb(28, 28, 28);
        static readonly Color SL_COLOR = Color.FromArgb(48, 48, 48);
        static readonly int ANIMATE_MAGNITUDE = 25;
        static readonly float ANIMATE_T = 0.3f;
        public TextModTab()
        {
            InitializeComponent();
            currentPosition = Location;
            deselectedGoal = Location;
            selectedGoal = new Point(Location.X +
                ANIMATE_MAGNITUDE, Location.Y);
            goalPosition = deselectedGoal;
        }
        private void TextModTab_MouseEnter(object sender, EventArgs e)
        {
            if(!selected)
                BackColor = HV_COLOR;
        }
        private void TextModTab_MouseLeave(object sender, EventArgs e)
        {
            if (!selected)
                BackColor = BG_COLOR;
        }
        public void TabSelect(object sender, EventArgs e)
        {
            if (Parent is TabList)
            {
                TabList list = Parent as TabList;
                list.DeselectAll();
                list.DispatchChange(page);
                list.selectedElement = this;
                list.selectedTab = page;
            }
            selected = true;
            BackColor = SL_COLOR;
            goalPosition = selectedGoal;
        }
        public void TabSelectQuiet(object sender, EventArgs e)
        {
            selected = true;
            BackColor = SL_COLOR;
            goalPosition = selectedGoal;
        }
        public void TabDeselect(object sender, EventArgs e)
        {
            selected = false;
            BackColor = BG_COLOR;
            goalPosition = deselectedGoal;
        }

        PointF currentPosition, goalPosition;
        readonly PointF deselectedGoal, selectedGoal;
        private void animationEvents_Tick(object sender, EventArgs e)
        {
            double dist = Visuals.Distance(currentPosition, goalPosition);

            if (dist < 0.45)
                return;

            float nx = Visuals.Interpolate(currentPosition.X, goalPosition.X, ANIMATE_T);
            float ny = Visuals.Interpolate(currentPosition.Y, goalPosition.Y, ANIMATE_T);
            currentPosition = new PointF(nx, ny);
            Point rounded = new Point((int)Math.Round(nx), (int)Math.Round(ny));
            titleLabel.Location = rounded;
        }
    }
}
