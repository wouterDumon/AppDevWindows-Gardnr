using Gardenr.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.ViewModels
{
    class SplitViewVM : ViewModelBase
    {
        public SplitViewVM()
        {
            Menu.Add(new MenuItem() { Glyph = "", Text = "Home", NavigationDestination = typeof(Home) });
            Menu.Add(new MenuItem() { Glyph = "", Text = "Profiel", NavigationDestination = typeof(Profiel) });
            Menu.Add(new MenuItem() { Glyph = "", Text = "Catalogus", NavigationDestination = typeof(Catalogus) });
            Menu.Add(new MenuItem() { Glyph = "", Text = "Instellingen", NavigationDestination = typeof(Instellingen) });

        }

    }
}
