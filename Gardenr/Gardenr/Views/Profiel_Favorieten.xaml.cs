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
            FrameworkElement parent = (FrameworkElement)((Button)sender).Parent;
            string parent_name = parent.Tag.ToString();



            a.UnfavoriteM(parent_name);


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


        /*
        VOOR DESKTOP   
        */

        private List<StackPanel> gridsFAV = new List<StackPanel>();
        private List<Ellipse> gridselFAV = new List<Ellipse>();

        private void ListItemsDESK_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            if (gridsFAV.Count != 0)
            {
                foreach (StackPanel mn in gridsFAV)
                {
                    mn.Height = ListItemsDESK.ActualHeight - 15;
                }
            }
            if (gridselFAV.Count != 0)
            {
                foreach (Ellipse mn in gridselFAV)
                {
                    mn.Width = ListItemsDESK.ActualHeight - 95;
                    mn.Height = ListItemsDESK.ActualHeight - 95;
                }
            }
        }

        private double berekenhoeveelitemsFAV(double a)
        {
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

        private void StackPanel_Loaded_1(object sender, RoutedEventArgs e)
        {

            StackPanel mn = sender as StackPanel;

            if (gridsFAV.Contains(mn)) { }
            else {
                gridsFAV.Add(mn);
            }
            mn.Height = ListItemsDESK.ActualHeight - 15;

        }

        private void Ellipse_Loaded_1(object sender, RoutedEventArgs e)
        {
            Ellipse mn = sender as Ellipse;

            if (gridselFAV.Contains(mn)) { }
            else {
                gridselFAV.Add(mn);
            }
            mn.Width = ListItemsDESK.ActualHeight - 95;
            mn.Height = ListItemsDESK.ActualHeight - 95;
        }
        private void ListItemsDESK_Tapped(object sender, TappedRoutedEventArgs e)
        {

            ProfielVM a = this.DataContext as ProfielVM;
            a.GoToPlant.Execute("iets");
        }
        //END FAV
        //BEGINHISTORIEK

        private List<StackPanel> gridsHIST = new List<StackPanel>();
        private List<Ellipse> gridselHIST = new List<Ellipse>();

        private void ListItemsHIST_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            if (gridsHIST.Count != 0)
            {
                foreach (StackPanel mn in gridsHIST)
                {
                    mn.Height = ListItemsHIST.ActualHeight - 15;
                }
            }
            if (gridselHIST.Count != 0)
            {
                foreach (Ellipse mn in gridselHIST)
                {
                    mn.Width = ListItemsHIST.ActualHeight - 95;
                    mn.Height = ListItemsHIST.ActualHeight - 95;
                }
            }
        }

        private void StackPanel_Loaded_2(object sender, RoutedEventArgs e)
        {
            StackPanel mn = sender as StackPanel;

            if (gridsHIST.Contains(mn)) { }
            else {
                gridsHIST.Add(mn);
            }
            mn.Height = ListItemsHIST.ActualHeight - 15;
        }

        private void Ellipse_Loaded_2(object sender, RoutedEventArgs e)
        {
            Ellipse mn = sender as Ellipse;

            if (gridselHIST.Contains(mn)) { }
            else {
                gridselHIST.Add(mn);
            }
            mn.Width = ListItemsHIST.ActualHeight - 95;
            mn.Height = ListItemsHIST.ActualHeight - 95;

        }

        private void ListItemsHIST_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ProfielVM a = this.DataContext as ProfielVM;
            a.GoToTuinObject.Execute("iets");
        }
        //HUIDIG
        private List<StackPanel> gridsHuidig = new List<StackPanel>();
        private List<Ellipse> gridselHuidig = new List<Ellipse>();

        private void ListItemsHUID_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
                        if (gridsHuidig.Count != 0)
                        {
                            foreach (StackPanel mn in gridsHuidig)
                            {
                    mn.Height = ListItemsHUID.ActualHeight - 15;
                }
                        }
                        if (gridselHuidig.Count != 0)
                        {
                            foreach (Ellipse mn in gridselHuidig)
                            {
                                      mn.Width = ListItemsHUID.ActualHeight - 95;
                    mn.Height = ListItemsHUID.ActualHeight - 95;
                                //    mn.Height = (ListItemsHUID.ActualWidth / berekenhoeveelitemsFAV(ListItemsHUID.ActualWidth)) - 15;
                            }
                        }
        }

        private void ListItemsHUID_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ProfielVM a = this.DataContext as ProfielVM;
            a.GoToTuinObject.Execute("iets");

        }

        private void StackPanel_Loaded_3(object sender, RoutedEventArgs e)
        {
            
            StackPanel mn = sender as StackPanel;

            if (gridsHuidig.Contains(mn)) { }
            else {
                gridsHuidig.Add(mn);
            }
            mn.Height = ListItemsHUID.ActualHeight -15;
            
        }

        private void Ellipse_Loaded_3(object sender, RoutedEventArgs e)
        {

            Ellipse mn = sender as Ellipse;

            if (gridselHuidig.Contains(mn)) { }
            else {
                gridselHuidig.Add(mn);
            }
            mn.Width = ListItemsHUID.ActualHeight - 95;
            mn.Height = ListItemsHUID.ActualHeight - 95;

            //mn.Height = (ListItemsHUID.ActualWidth / berekenhoeveelitemsFAV(ListItemsHUID.ActualWidth)) - 15;
        }
    }
}
