using Gardenr.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class Instellingen : Page
    {
        public Instellingen()
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
            ini();

        }
        private async void ini()
        {
            try
            {
                Windows.Storage.StorageFile sampleFile = null;
                sampleFile =
                         sampleFile =
await storageFolder.CreateFileAsync("weer.txt",
Windows.Storage.CreationCollisionOption.OpenIfExists);
                //indien file bestaat
                string text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
                if (text != "")
                {
                    string[] df = text.Split(';');

                    WAARBENIK.Text = "" + df[0] + "," + df[1];
                }
            }
            catch (Exception e)
            {
                Exception mijnexceptie = e;

            }

        }
 
        private void c() {
            InstellingenVM i = this.DataContext as InstellingenVM;
            i.SaveSettings.Execute(""); 
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            c();
        }

        async private void df()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();

            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:

                    // Get cancellation token
                    _cts = new CancellationTokenSource();
                    CancellationToken token = _cts.Token;

                    //_rootPage.NotifyUser("Bezig met ophalen van data", AppShell.NotifyType.StatusMessage);
                    ophalen.Visibility = Visibility.Visible;
                    // If DesiredAccuracy or DesiredAccuracyInMeters are not set (or value is 0), DesiredAccuracy.Default is used.
                    Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = _desireAccuracyInMetersValue };

                    // Carry out the operation
                    Geoposition pos = await geolocator.GetGeopositionAsync().AsTask(token);

                    UpdateLocationData(pos);
                    //ophalen.Visibility = Visibility.Collapsed;
                    break;

                case GeolocationAccessStatus.Denied:
                    //_rootPage.NotifyUser("Access to location is denied.", AppShell.NotifyType.ErrorMessage);
                    LocationDisabledMessage.Visibility = Visibility.Visible;
                    UpdateLocationData(null);
                    break;

                case GeolocationAccessStatus.Unspecified:
                    //_rootPage.NotifyUser("Unspecified error.", AppShell.NotifyType.ErrorMessage);
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

        private async void ShowSatalliteData(bool v)
        {
            //klaar roep vm op
            string lat = ScenarioOutput_Latitude;
            string lon = ScenarioOutput_Longitude;
            string stad = "";
            string land = "";
            /*WebClient client = new WebClient();
            string strLatitude = " 13.00";
            string strLongitude = "80.25";
            client.DownloadStringCompleted += client_DownloadStringCompleted;
            string Url = "http://maps.googleapis.com/maps/api/geocode/json?latlng=" + lat + "," + lon + "&sensor=true";
            client.DownloadStringAsync(new Uri(Url, UriKind.RelativeOrAbsolute));
            Console.Read();*/

            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                client.BaseAddress = new Uri("http://maps.googleapis.com/maps/api/geocode/");
                HttpResponseMessage response = client.GetAsync("json?latlng=" + lat + "," + lon + "&sensor=true").Result;
                response.EnsureSuccessStatusCode();
                var result = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                var getJsonres = result["results"][0];
                var getJson = getJsonres["address_components"][2];
                var getcity = getJson["long_name"];
                var getJfson = getJsonres["address_components"][5];
                var getcountry = getJfson["long_name"];
                stad = getcity.ToString();
                land = getcountry.ToString();
              
            }
          


            await weefr(stad,land,lat, lon);
            ophalen.Visibility = Visibility.Collapsed;
            //
        


        }

        /*static void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var getResult = e.Result;
            JObject parseJson = JObject.Parse(getResult);
            var getJsonres = parseJson["results"][0];
            var getJson = getJsonres["address_components"][1];
            var getAddress = getJson["long_name"];
            string Address = getAddress.ToString();
        }*/

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
        private Windows.Storage.StorageFolder storageFolder =
Windows.Storage.ApplicationData.Current.LocalFolder;
        //private  Windows.Storage.StorageFile sampleFile = null;



        private async Task weefr(string s, string l,string lat, string lon)
        {
            try
            {
                Windows.Storage.StorageFile sampleFile = null;
                sampleFile =
                         sampleFile =
await storageFolder.CreateFileAsync("weer.txt",
Windows.Storage.CreationCollisionOption.ReplaceExisting);
                //indien file bestaat
                //string text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);

                await Windows.Storage.FileIO.WriteTextAsync(sampleFile, s+";"+l+";"+lat + ";" + lon);
                WAARBENIK.Text = "" + s + "," + l;

            }
            catch (Exception e)
            {
                Exception mijnexceptie = e;

            }



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            df();
        }
    }
    }
