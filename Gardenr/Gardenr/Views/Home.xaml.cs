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

            df();

        }
       
        private Shell _rootPage = Shell.Current;

        async private void df() {
            var accessStatus = await Geolocator.RequestAccessAsync();
            
            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:

                    // Get cancellation token
                    _cts = new CancellationTokenSource();
                    CancellationToken token = _cts.Token;

                    _rootPage.NotifyUser("Bezig met ophalen van data", Shell.NotifyType.StatusMessage);

                    // If DesiredAccuracy or DesiredAccuracyInMeters are not set (or value is 0), DesiredAccuracy.Default is used.
                    Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = _desireAccuracyInMetersValue };
                    
                    // Carry out the operation
                    Geoposition pos = await geolocator.GetGeopositionAsync().AsTask(token);

                    UpdateLocationData(pos);
                    _rootPage.NotifyUser("", Shell.NotifyType.StatusMessage);
                    break;

                case GeolocationAccessStatus.Denied:
                    _rootPage.NotifyUser("Access to location is denied.", Shell.NotifyType.ErrorMessage);
                    LocationDisabledMessage.Visibility = Visibility.Visible;
                    UpdateLocationData(null);
                    break;

                case GeolocationAccessStatus.Unspecified:
                    _rootPage.NotifyUser("Unspecified error.", Shell.NotifyType.ErrorMessage);
                    UpdateLocationData(null);
                    break;
            }

        }
        private void UpdateLocationData(Geoposition position)
        {
            if (position == null)
            {
                ScenarioOutput_Latitude = "No data";
                ScenarioOutput_Longitude = "No data";
                ScenarioOutput_Accuracy = "No data";
                ScenarioOutput_Source = "No data";
                //ShowSatalliteData(false);
            }
            else
            {
                ScenarioOutput_Latitude = position.Coordinate.Point.Position.Latitude.ToString();
                ScenarioOutput_Longitude = position.Coordinate.Point.Position.Longitude.ToString();
                ScenarioOutput_Accuracy = position.Coordinate.Accuracy.ToString();
                ScenarioOutput_Source = position.Coordinate.PositionSource.ToString();

                if (position.Coordinate.PositionSource == PositionSource.Satellite)
                {
                    // Show labels and satellite data when available
                    ScenarioOutput_PosPrecision = position.Coordinate.SatelliteData.PositionDilutionOfPrecision.ToString();
                    ScenarioOutput_HorzPrecision = position.Coordinate.SatelliteData.HorizontalDilutionOfPrecision.ToString();
                    ScenarioOutput_VertPrecision = position.Coordinate.SatelliteData.VerticalDilutionOfPrecision.ToString();
                    ShowSatalliteData(true);
                }
                else
                {
                    // Hide labels and satellite data
                    ShowSatalliteData(false);
                }
            }
        }

        private void ShowSatalliteData(bool v)
        {
            //klaar roep vm op
            string lat =ScenarioOutput_Latitude;
            string lon = ScenarioOutput_Longitude;
            HomeVM hdata = (HomeVM)this.DataContext;
            hdata.FILLUPWEER(lat, lon);

        }

        // Captures the value entered by user.
        private uint _desireAccuracyInMetersValue = 0;
        private CancellationTokenSource _cts = null;

        public string ScenarioOutput_Longitude { get; private set; }
        public string ScenarioOutput_Latitude { get; private set; }
        public string ScenarioOutput_Accuracy { get; private set; }
        public string ScenarioOutput_Source { get; private set; }
        public string ScenarioOutput_PosPrecision { get; private set; }
        public string ScenarioOutput_HorzPrecision { get; private set; }
        public string ScenarioOutput_VertPrecision { get; private set; }

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
