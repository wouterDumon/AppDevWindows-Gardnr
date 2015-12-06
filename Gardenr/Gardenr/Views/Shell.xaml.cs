using Gardenr.Models;
using Gardenr.ViewModels;
using Microsoft.WindowsAzure.Messaging;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Windows.Networking.PushNotifications;
using Windows.Networking.PushNotifications;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Gardenr.Views
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Shell : Page
    {
       
        //INDIEN LUKT OMZETTEN NAAR MVVM
        public Shell()
        {
            this.InitializeComponent();
           // var type = (DataContext as SplitViewVM).Menu.First().NavigationDestination;
            SplitViewFrame.Navigate(typeof(Home));
            App.frame = SplitViewFrame;
           SetupNotificationsHub();
        }
        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var menuItem = e.AddedItems.First() as MenuItem;
                if (menuItem.IsNavigation)
                {
                    SplitViewFrame.Navigate(menuItem.NavigationDestination);
                }
                else
                {
                    menuItem.Command.Execute(null);
                }
            }
        }

        private void SplitViewOpener_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.X > 50)
            {
                MySplitView.IsPaneOpen = true;
            }
        }
        private PushNotificationChannel channel = null;
        private async void SetupNotificationsHub()
        {
            channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
            var hub = new NotificationHub("notific", "Endpoint=sb://gardenrnotif.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=8bPfKiz9h4jY/e0JtAUqN/tCybd+dOtj3X/tA6zndxM=");
            channel.PushNotificationReceived += Channel_PushNotificationReceived;
            var result = await hub.RegisterNativeAsync(channel.Uri);
            if (result.RegistrationId != null)
            {
               // var dialog = new MessageDialog("Registratie ok");
              //  dialog.Commands.Add(new UICommand("Ok"));
             //   await dialog.ShowAsync();
                //  await sendPush("wns", App.FacebookId, "troll");
                LoginAndRegisterClick();
            }
            else
            {
              //  var dialog = new MessageDialog("Failed");
               // dialog.Commands.Add(new UICommand("Ok"));
                //await dialog.ShowAsync();
            }
        }

        private void Channel_PushNotificationReceived(PushNotificationChannel sender, PushNotificationReceivedEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void SplitViewPane_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.X < -50)
            {
                MySplitView.IsPaneOpen = false;
            }
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
       


        private async void LoginAndRegisterClick()
        {
            //SetAuthenticationTokenInLocalStorage();

            var channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();

            // The "username:<user name>" tag gets automatically added by the message handler in the backend.
            // The tag passed here can be whatever other tags you may want to use.
            try
            {
                // The device handle used will be different depending on the device and PNS. 
                // Windows devices use the channel uri as the PNS handle.
                await new RegisterClient(App.BACKEND_ENDPOINT).RegisterAsync(channel.Uri, new string[] { ""+App.FacebookId });

//                var dialog = new MessageDialog("Registered as: ");
  //              dialog.Commands.Add(new UICommand("OK"));
    //            await dialog.ShowAsync();
           
            }
            catch (Exception ex)
            {
            //    MessageDialog alert = new MessageDialog(ex.Message, "Failed to register with RegisterClient");
              //  alert.ShowAsync();
            }
        }      
    }
}
