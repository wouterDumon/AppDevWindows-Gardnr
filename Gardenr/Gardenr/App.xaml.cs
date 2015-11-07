using Facebook;
using GalaSoft.MvvmLight.Messaging;
using Gardenr.Mesages;
using Gardenr.Models;
using Gardenr.Views;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Gardenr
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        internal static string AccessToken = String.Empty;
        internal static string FacebookId = String.Empty;
        public static bool isAuthenticated = false;

       /* public static MobileServiceClient MobileService = new MobileServiceClient(
          "http://localhost:58704"
);*/
        // Use this constructor instead after publishing to the cloud
         public static MobileServiceClient MobileService = new MobileServiceClient(
              "https://gardenr.azure-mobile.net/",
              "ptPDBKzoOzchVLZwMfMjmNVpzNTihg33"
        );
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
                Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
                Microsoft.ApplicationInsights.WindowsCollectors.Session);
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        private void NavigateToPage(GoToPageMessage message)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if(message.PageNumber == 1) // catalogus pagina
            {
                rootFrame.Navigate(typeof(Catalogus));
            }
            else if (message.PageNumber == 2) // catalogus plant pagina
            {
                rootFrame.Navigate(typeof(CatalogusPlant),message.SelectedPlant);
  
            }
            else if(message.PageNumber == 3) // contact pagina
            {
                rootFrame.Navigate(typeof(Contact));
            }
            else if(message.PageNumber == 4) // instellingen pagina
            {
                rootFrame.Navigate(typeof(Views.Instellingen));
            }
            else if (message.PageNumber == 5) //Notificaties pagina
            {
                rootFrame.Navigate(typeof(Views.Notificaties));
            }
            else if(message.PageNumber == 6) // Notificaties bewerken pagina
            {
                rootFrame.Navigate(typeof(NotificatiesBewerken));
            }
            else if (message.PageNumber == 7) // Plant bewerken pagina
            {
                rootFrame.Navigate(typeof(PlantBewerken));
            }
            else if(message.PageNumber == 8) // Profiel historiek pagina
            {
                rootFrame.Navigate(typeof(Profiel_Historiek));
            }
            else if (message.PageNumber == 9) // profiel favorieten pagina
            {
                rootFrame.Navigate(typeof(Profiel_Favorieten));
            }
            else if(message.PageNumber == 10) // profiel plantinfo pagina
            {
                rootFrame.Navigate(typeof(Profiel_PlantInfo));
            }
            else if(message.PageNumber == 1)//home page
            {
                rootFrame.Navigate(typeof(Home));
            }
            /*if (message.PageNumber == 1)
            {
                rootFrame.Navigate(typeof(Page2));
            }*/
        }
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {

#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif
            Messenger.Default.Register<GoToPageMessage>(this, NavigateToPage);
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
