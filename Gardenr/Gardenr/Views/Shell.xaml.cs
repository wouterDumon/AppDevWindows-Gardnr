using Gardenr.ViewModels;
using Microsoft.WindowsAzure.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.PushNotifications;
using Windows.UI.Popups;
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
    public sealed partial class Shell : Page
    {
        //INDIEN LUKT OMZETTEN NAAR MVVM
        public Shell()
        {
            this.InitializeComponent();
           // var type = (DataContext as SplitViewVM).Menu.First().NavigationDestination;
            SplitViewFrame.Navigate(typeof(Home));
            App.frame = SplitViewFrame;
         //   SetupNotificationsHub();
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
            var hub = new NotificationHub("gardnotif", "Endpoint=sb://gardenr.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=0cxmkySgALisaXPBhX+2qfF+KP4lNduhmJ5IhIDFMRQ=");
            channel.PushNotificationReceived += Channel_PushNotificationReceived;
            var result = await hub.RegisterNativeAsync(channel.Uri);
            if (result.RegistrationId != null)
            {
                var dialog = new MessageDialog("Registratie ok");
                dialog.Commands.Add(new UICommand("Ok"));
                await dialog.ShowAsync();
            }
            else
            {
                var dialog = new MessageDialog("Failed");
                dialog.Commands.Add(new UICommand("Ok"));
                await dialog.ShowAsync();
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
    }
}
