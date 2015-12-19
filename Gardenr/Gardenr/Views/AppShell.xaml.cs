using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Gardenr.Models;
using Gardenr.ViewModels;
using Microsoft.WindowsAzure.Messaging;
using Windows.Networking.PushNotifications;
using Windows.UI;
using Windows.UI.ViewManagement;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Gardenr.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppShell : Page
    {
       

        public static AppShell Current = null;

        /// <summary>
        /// Initializes a new instance of the AppShell, sets the static 'Current' reference,
        /// adds callbacks for Back requests and changes in the SplitView's DisplayMode, and
        /// provide the nav menu list with the data to display.
        /// </summary>
        public AppShell()
        {
            this.InitializeComponent();

            this.Loaded += (sender, args) =>
            {
                Current = this;
                mijnhamburger = HamburgerButton;
                SetupNotificationsHub();
                setuptitle();
            };
           
        }

        public static Button mijnhamburger;


        public void setuptitle()
        {
            var view = ApplicationView.GetForCurrentView();

            view.TitleBar.BackgroundColor = Colors.DarkGreen;
            view.TitleBar.ForegroundColor = Colors.White;

            view.TitleBar.ButtonBackgroundColor = Colors.DarkGreen;
            view.TitleBar.ButtonForegroundColor = Colors.White;

            view.TitleBar.ButtonHoverBackgroundColor = Colors.Green;
            view.TitleBar.ButtonHoverForegroundColor = Colors.White;

            view.TitleBar.ButtonPressedBackgroundColor = Color.FromArgb(255, 0, 120, 0);
            view.TitleBar.ButtonPressedForegroundColor = Colors.White;

            view.TitleBar.ButtonInactiveBackgroundColor = Colors.DarkGray;
            view.TitleBar.ButtonInactiveForegroundColor = Colors.Gray;

            view.TitleBar.InactiveBackgroundColor = Colors.DarkGreen;
            view.TitleBar.InactiveForegroundColor = Colors.Gray;
        }

        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (e.AddedItems.Count > 0)
            {
                var menuItem = e.AddedItems.First() as MenuItem;
                if (menuItem.IsNavigation)
                {
                    if (menuItem.NavigationDestination == typeof(Home))
                    {

                    }
                    else
                    {
                        
                    }
                    MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
                    this.AppFrame.Navigate(menuItem.NavigationDestination);
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
            try
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
            catch (Exception e)
            {

                Exception j = e;
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
                await new RegisterClient(App.BACKEND_ENDPOINT).RegisterAsync(channel.Uri, new string[] { "" + App.Gebruiker.ID });

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

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        public Frame AppFrame { get { return this.frame; } }
        private Windows.Storage.StorageFolder storageFolder =
Windows.Storage.ApplicationData.Current.LocalFolder;
        private async void df_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //LOGOUT :-)
            try
            {
                Windows.Storage.StorageFile sampleFile = null;
                sampleFile =
                         sampleFile =
await storageFolder.CreateFileAsync("islogin.txt",
Windows.Storage.CreationCollisionOption.ReplaceExisting);
                sampleFile =
                sampleFile =
await storageFolder.CreateFileAsync("weer.txt",
Windows.Storage.CreationCollisionOption.ReplaceExisting);
                App.returntologin();

            }
            catch (Exception error)
            {


            }
        }
    }
}
