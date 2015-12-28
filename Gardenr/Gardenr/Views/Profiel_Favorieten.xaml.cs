using Gardenr.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Gardenr.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Profiel_Favorieten : Page
    {
        public Profiel_Favorieten()
        {
            this.InitializeComponent();
           
#if (!DEBUG)
                    //kijken of release > ADS MOGEN NIET IN TEST GEBRUIKT WORDEN
               bool isHardwareButtonsAPIPresent =
        Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");
            if (isHardwareButtonsAPIPresent)
            {
                //IS MOBILE

                add.AdUnitId = App.MobileADID;
                add.ApplicationId = App.MobileappID;
            }
            else {
                //is desktop
                add.AdUnitId = App.adID;
                add.ApplicationId = App.appID;
            }
           
#endif
        }

        private void ListItems_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ProfielVM a = this.DataContext as ProfielVM;
            a.GoToPlant.Execute("iets");
        }

        private void Position_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ProfielVM a = this.DataContext as ProfielVM;

            
           
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            StackPanel mn = sender as StackPanel;

            if (grids.Contains(mn)) { }
            else {
                grids.Add(mn);
            }
            mn.Width = (ListItems.ActualWidth / berekenhoeveelitems()) - 5;
        }

        private List<StackPanel> grids = new List<StackPanel>();
        private List<Ellipse> gridsel = new List<Ellipse>();

        private int berekenhoeveelitems()
        {
            Double a = Window.Current.Bounds.Width;
            if (a > 1300) return 8;
            else
            if (a > 1150) return 7;
            else if (a > 1000)
            {
                return 6;
            }
            else if (a > 850) return 5;
            else if (a > 700)
            {
                return 4;
            }
            else {
                return 3;
            }

        }

        private void ListItems_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (grids.Count != 0)
            {
                foreach (StackPanel mn in grids)
                {
                    mn.Width = (ListItems.ActualWidth / berekenhoeveelitems()) - 5;
                }
            }
            if (gridsel.Count != 0)
            {
                foreach (Ellipse mn in gridsel)
                {
                    mn.Width = (ListItems.ActualWidth / berekenhoeveelitems()) - 15;
                    mn.Height = (ListItems.ActualWidth / berekenhoeveelitems()) - 15;
                }
            }
        }

        private void Ellipse_Loaded(object sender, RoutedEventArgs e)
        {
            Ellipse mn = sender as Ellipse;

            if (gridsel.Contains(mn)) { }
            else {
                gridsel.Add(mn);
            }
            mn.Width = (ListItems.ActualWidth / berekenhoeveelitems()) - 15;
            mn.Height = (ListItems.ActualWidth / berekenhoeveelitems()) - 15;
        }
    }
}
