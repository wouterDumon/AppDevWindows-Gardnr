using Gardenr.Mesages;
using Gardenr.Models;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Gardenr.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Notificaties : Page
    {
        public Notificaties()
        {
            this.InitializeComponent();
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


            bool isHardwareButtonsAPIPresent2 =
     Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");
            if (isHardwareButtonsAPIPresent2)
            {
                //IS MOBILE
                Puntjes.Margin = new Thickness(-15, 0, -15, 0);

            }
            else { }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NotificatiesVM a = this.DataContext as NotificatiesVM;
            NotificatieMessage temp = e.Parameter as Gardenr.Mesages.NotificatieMessage;
            // a.IngesteldeNotificaties = e.Parameter as Gardenr.Models.Notificaties;
            a.IngesteldeNotificaties = temp.SelectedNotificatie;
            
            
            
        }
    }
}
