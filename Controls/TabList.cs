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

namespace TextMod_2.Controls
{
    public partial class TabList : UserControl
    {
        public TextModPage selectedTab = TextModPage.HOME;
        public TextModTab selectedElement = null;

        public delegate void OnPageSwitchedHandler(TextModPage newPage);
        public event OnPageSwitchedHandler OnPageSwitched;

        public void DeselectAll()
        {
            tab_HOME.TabDeselect(null, new EventArgs());
            tab_COMMANDS.TabDeselect(null, new EventArgs());
            tab_IMAGE_COMMANDS.TabDeselect(null, new EventArgs());
            tab_EMOJI.TabDeselect(null, new EventArgs());
            tab_SCRIPTING.TabDeselect(null, new EventArgs());
            tab_RICH_PRESENCE.TabDeselect(null, new EventArgs());
            tab_UTILITIES.TabDeselect(null, new EventArgs());
        }
        public void DispatchChange(TextModPage newPage)
        {
            OnPageSwitched?.Invoke(newPage);
        }
        public TabList()
        {
            InitializeComponent();
            GoHome();
        }
        public void GoHome()
        {
            tab_HOME.TabSelect(null, new EventArgs());
        }
        public void ExternalSelectPage(TextModPage page)
        {
            switch (page)
            {
                case TextModPage.HOME:
                    tab_HOME.TabSelect(null, new EventArgs());
                    break;
                case TextModPage.COMMANDS:
                    tab_COMMANDS.TabSelect(null, new EventArgs());
                    break;
                case TextModPage.IMAGE_COMMANDS:
                    tab_IMAGE_COMMANDS.TabSelect(null, new EventArgs());
                    break;
                case TextModPage.EMOJI:
                    tab_EMOJI.TabSelect(null, new EventArgs());
                    break;
                case TextModPage.SCRIPTING:
                    tab_SCRIPTING.TabSelect(null, new EventArgs());
                    break;
                case TextModPage.RICH_PRESENCE:
                    tab_RICH_PRESENCE.TabSelect(null, new EventArgs());
                    break;
                case TextModPage.UTILITIES:
                    tab_UTILITIES.TabSelect(null, new EventArgs());
                    break;
                default:
                    break;
            }
        }
    }
}
