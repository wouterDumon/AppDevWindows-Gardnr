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
using Gardenr.ViewModels;
using Windows.Devices.Geolocation;
using Windows.UI.Core;
using System.Threading;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Gardenr.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        public Home()
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
            getmesomething();
           

        }
        private Windows.Storage.StorageFolder storageFolder =
Windows.Storage.ApplicationData.Current.LocalFolder;
        private async void getmesomething() {
            HomeVM a = this.DataContext as HomeVM;
            String heeftweer = await a.getweather(App.Gebruiker.InstellingenID);
            

            try
            {
                Windows.Storage.StorageFile sampleFile = null;
                sampleFile =
                         sampleFile =
await storageFolder.CreateFileAsync("weer.txt",
Windows.Storage.CreationCollisionOption.OpenIfExists);
                //indien file bestaat
                string text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
                if (text == "" && heeftweer== "")
                {
                    await Windows.Storage.FileIO.WriteTextAsync(sampleFile, "Kortrijk" + ";" + "Belgium" + ";" + "50.83053" + ";" + "3.26446");
                    HomeVM hdata = (HomeVM)this.DataContext;
                    hdata.FILLUPWEER("50.83053", "3.26446");
                }
                else {
                    if (heeftweer != "")
                    {
                        string[] ddf = heeftweer.Split(';');
                        await Windows.Storage.FileIO.WriteTextAsync(sampleFile, ddf[0] + ";" + ddf[1] + ";" + ddf[2] + ";" + ddf[3]);
                        HomeVM hdatad = (HomeVM)this.DataContext;
                        hdatad.FILLUPWEER(ddf[2], ddf[3]);

                    }
                    else {



                        string[] df = text.Split(';');
                        HomeVM hdata = (HomeVM)this.DataContext;
                        hdata.FILLUPWEER(df[2], df[3]);
                    }
                }
               // 
               // WAARBENIK.Text = "Huidige ingestelde locatie: " + s + "," + l;

            }
            catch (Exception e)
            {
                Exception mijnexceptie = e;


            }
        }

        private void ListItems_Tapped(object sender, TappedRoutedEventArgs e)
        {
            HomeVM a = this.DataContext as HomeVM;
            a.VieuwNotification.Execute("iets");
        }

        private void NiewsItems_Tapped(object sender, TappedRoutedEventArgs e)
        {
            HomeVM a = this.DataContext as HomeVM;
            a.VieuwNieuwsItem.Execute("iets");
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            HomeVM a = this.DataContext as HomeVM;
            a.AddNotificatie.Execute("iets");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//ListItems
            if (ListItems.SelectedIndex < ListItems.Items.Count - 1)
                ListItems.SelectedIndex++;
            ListItems.ScrollIntoView(ListItems.SelectedItem);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ListItems.SelectedIndex > 0)
                ListItems.SelectedIndex--;
            ListItems.ScrollIntoView(ListItems.SelectedItem);

        }
    }
}
