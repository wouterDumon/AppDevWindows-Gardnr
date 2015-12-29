using Gardenr.Models;
using Gardenr.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
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
    public sealed partial class PlantBewerken : Page
    {
        public PlantBewerken()
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


            dosomething();
            bool isHardwareButtonsAPIPresent =
     Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");
            if (isHardwareButtonsAPIPresent)
            {
                //IS MOBILE
                Puntjes.Margin = new Thickness(-15, 0, -15, 0);

            }
            else { }
        }

        private String t = "";
        private async void dosomething()
        {

            PlantBewerkenVM a = this.DataContext as PlantBewerkenVM;
            t = await a.CheckFavoriet();
            APPBAR.Label = t;
        }

        private void ListItems_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PlantBewerkenVM a = this.DataContext as PlantBewerkenVM;
            a.GoNotification.Execute("iets");
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            PlantBewerkenVM a = this.DataContext as PlantBewerkenVM;
            a.TeBewerkenTuin = e.Parameter as Tuin;
            a.Startup();

        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PlantBewerkenVM a = this.DataContext as PlantBewerkenVM;
            a.AddNotification.Execute("iets");
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PlantBewerkenVM a = this.DataContext as PlantBewerkenVM;
            a.GoBack.Execute("lalaala");
        }

        private async void APPBAR_Click(object sender, RoutedEventArgs e)
        {
            PlantBewerkenVM a = this.DataContext as PlantBewerkenVM;
            await a.AddFavo();
            if (t.Equals("Toevoegen aan favorieten"))
            {
                zend("Succesvol aan favorieten toegevoegd");
                APPBAR.Label = "Verwijder uit favorieten";
            }
            else {
                zend("Succesvol uit favorieten gehaald");
                APPBAR.Label = "Toevoegen aan favorieten";
            }
        }
        private void zend(String t)
        {
            // Clear all existing notifications
            ToastNotificationManager.History.Clear();

            var longTime = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("longtime");
            DateTimeOffset expiryTime = DateTime.Now.AddSeconds(10);
            string expiryTimeString = longTime.Format(expiryTime);

            Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            //Find the text component of the content
            Windows.Data.Xml.Dom.XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");

            // Set the text on the toast. 
            // The first line of text in the ToastText02 template is treated as header text, and will be bold.
            toastTextElements[0].AppendChild(toastXml.CreateTextNode("Info"));
            toastTextElements[1].AppendChild(toastXml.CreateTextNode(t));

            // Set the duration on the toast
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((Windows.Data.Xml.Dom.XmlElement)toastNode).SetAttribute("duration", "long");

            // Create the actual toast object using this toast specification.
            ToastNotification toast = new ToastNotification(toastXml);

            toast.ExpirationTime = expiryTime;

            // Send the toast.
            ToastNotificationManager.CreateToastNotifier().Show(toast);

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            doiets();
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            doiets();
        }

        private void doiets()
        {
            bool isHardwareButtonsAPIPresent =
       Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");
            if (isHardwareButtonsAPIPresent)
            {
                //IS MOBILE
                Double a = Window.Current.Bounds.Width;
                if (a > 1200)
                {
                    ROW2.Height = new GridLength(320);
                }
                else if (a > 800)
                {
                    ROW2.Height = new GridLength(150);
                }
                else {
                    ROW2.Height = new GridLength(100);
                }

            }
            else {

                Double a = Window.Current.Bounds.Width;
                if (a > 1200)
                {
                    ROW2.Height = new GridLength(250);
                }
                else if (a > 800)
                {
                    ROW2.Height = new GridLength(200);
                }
                else {
                    ROW2.Height = new GridLength(150);
                }
            }
        }
        private List<Grid> grids = new List<Grid>();
        private void ListItems_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (grids.Count != 0)
            {
                foreach (Grid mn in grids)
                {
                    mn.Width = (ListItems.ActualWidth / berekenhoeveelitems()) - 5;


                }
            }
        }

        private double berekenhoeveelitems()
        {


            Double a = Window.Current.Bounds.Width;
            if (a > 1600)
            {
                return 10;
            }
            else
            if (a > 1200)
            {
                return 8;
            }
            else if (a > 1000)
            {
                return 6;
            }
            else if (a > 700)
            {
                return 5;
            }
            else if (a > 500)
            {
                return 4;
            }
            else {
                return 3;
            }
        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            Grid mn = sender as Grid;

            if (grids.Contains(mn)) { }
            else {
                grids.Add(mn);
            }
            mn.Width = (ListItems.ActualWidth / berekenhoeveelitems()) - 5;


        }
    }
}
