using Gardenr.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Gardenr.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Catalogus : Page
    {
        public Catalogus()
        {
            this.InitializeComponent();
            //  var sdkfjslkqdfj =  Screen.PrimaryScreen.Bounds.Width;
            //   var x = 0;

#if (!DEBUG)
                    //kijken of release > ADS MOGEN NIET IN TEST GEBRUIKT WORDEN
               bool isHardwareButtonsAPIPresent =
        Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");
            if (isHardwareButtonsAPIPresent)
            {
                //IS MOBILE
                add.Width = 480;
                add.Height = 80;
                // add2.Width = 480;
                // add2.Height = 80;
                add.AdUnitId = App.MobileADID;
                add.ApplicationId = App.MobileappID;
                // add2.AdUnitId = App.MobileADID;
                // add2.ApplicationId = App.MobileappID;
            }
            else {
                //is desktop
                add.Width = 728;
                add.Height = 90;
                // add2.Width = 728;
                // add2.Height = 90;
                add.AdUnitId = App.adID;
                add.ApplicationId = App.appID;
                //add2.AdUnitId = App.adID;
                //add2.ApplicationId = App.appID;
            }


#endif

            var bla = ApplicationView.GetForCurrentView().VisibleBounds;
            double adjf = bla.Width;
            CatalogusVM a = this.DataContext as CatalogusVM;
            double sd = adjf / 2;
            
            a.width = (""+sd);
        }

        private void ListItems_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CatalogusVM a = this.DataContext as CatalogusVM;
            a.GoToDetail.Execute("h"); 
        }
       private List<Grid> grids= new List<Grid>();

        private int berekenhoeveelitems() {
            Double a = Window.Current.Bounds.Width;
            if (a > 1200)
            {
                return 4;
            }
            else if (a > 700)
            {
                return 3;
            }
            else {
                return 2;
            }
   
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Grid mn = sender as Grid;
   
            if (grids.Contains(mn)) { }
            else {
                grids.Add(mn);
            }
            mn.Width = (ListItems.ActualWidth / berekenhoeveelitems()) -5;
        }

        private void ListItems_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (grids.Count != 0) {
                foreach (Grid mn in grids) {
                    mn.Width = (ListItems.ActualWidth / berekenhoeveelitems()) - 5;
                }
            }
        }
    }
}
