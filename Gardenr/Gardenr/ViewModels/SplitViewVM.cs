using Gardenr.Models;
using Gardenr.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.ViewModels
{
    class SplitViewVM : ViewModelBase
    {
        private ObservableCollection<DrawerInstellingen> _custom;

        public ObservableCollection<DrawerInstellingen> Custom
        {
            get { return _custom; }
            set { _custom = value; }
        }


        public SplitViewVM()
        {
            if (Menu.Count() == 0) {

                Custom = new ObservableCollection<DrawerInstellingen>();
                Menu.Add(new MenuItem() { Glyph = "", Text = "Home", NavigationDestination = typeof(Home) });
                Menu.Add(new MenuItem() { Glyph = "", Text = "Profiel", NavigationDestination = typeof(Profiel) });
                Menu.Add(new MenuItem() { Glyph = "", Text = "Catalogus", NavigationDestination = typeof(Catalogus) });
                DrawerInstellingen d = new DrawerInstellingen();
                d.Naam = "" + App.Gebruiker.Voornaam + " " + App.Gebruiker.Naam;
                d.Fotourl = App.Fotourl;
                Custom.Add(d);
                //   cus.Add(new MenuItem() { Glyph = "", Text = "Log out", NavigationDestination = typeof(Instellingen) });
                Menu.Add(new MenuItem() { Glyph = "", Text = "Instellingen", NavigationDestination = typeof(Gardenr.Views.Instellingen) });
            }
           else {
                Custom = new ObservableCollection<DrawerInstellingen>();
                DrawerInstellingen d = new DrawerInstellingen();
                d.Naam = "" + App.Gebruiker.Voornaam + " " + App.Gebruiker.Naam;
                d.Fotourl = App.Fotourl;
                Custom.Add(d);
            }
           
            

        }

    }
}
