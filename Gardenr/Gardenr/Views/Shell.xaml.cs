using Gardenr.Models;
using Gardenr.ViewModels;
using Microsoft.WindowsAzure.Messaging;
using System;
using System.Linq;
using Windows.Networking.PushNotifications;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Gardenr.Views
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Shell : Page
    {
        public static Shell Current;

        //INDIEN LUKT OMZETTEN NAAR MVVM
        public Shell()
        {
            this.InitializeComponent();
            Current = this;
            setuptitle();
            
            // var type = (DataContext as SplitViewVM).Menu.First().NavigationDestination;
            SplitViewFrame.Navigate(typeof(Home));
            App.frame = SplitViewFrame;
           SetupNotificationsHub();
        }
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
                    if (menuItem.NavigationDestination == typeof(Home)) {

                    } else {
                        StatusBorder.Visibility = Visibility.Collapsed;
                        StatusPanel.Visibility = Visibility.Collapsed;
                    }
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


        public enum NotifyType
        {
            StatusMessage,
            ErrorMessage
        };
        public void NotifyUser(string strMessage, NotifyType type)
        {
            /*switch (type)
            {
                case NotifyType.StatusMessage:
                    StatusBorder.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                    break;
                case NotifyType.ErrorMessage:
                    StatusBorder.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    break;
            }*/
            StatusBlock.Text = strMessage;

            // Collapse the StatusBlock if it has no text to conserve real estate.
            StatusBorder.Visibility = (StatusBlock.Text != String.Empty) ? Visibility.Visible : Visibility.Collapsed;
            if (StatusBlock.Text != String.Empty)
            {
                StatusBorder.Visibility = Visibility.Visible;
                StatusPanel.Visibility = Visibility.Visible;
                LoadingBaaar.IsActive = true;
            }
            else
            {
                StatusBorder.Visibility = Visibility.Collapsed;
                StatusPanel.Visibility = Visibility.Collapsed;
                LoadingBaaar.IsActive = false;
            }
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
                await new RegisterClient(App.BACKEND_ENDPOINT).RegisterAsync(channel.Uri, new string[] { ""+App.Gebruiker.ID });

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
