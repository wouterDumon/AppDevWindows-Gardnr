using GalaSoft.MvvmLight.Messaging;
using Gardenr.Mesages;
using Gardenr.Models;
using Gardenr.Views;
using Microsoft.WindowsAzure.Messaging;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Media.SpeechRecognition;
using Windows.Networking.PushNotifications;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
        internal static string Fotourl = String.Empty;
        internal static Gebruiker Gebruiker = null;
        internal static string BACKEND_ENDPOINT = "http://notifgardenr.azurewebsites.net/";
        public static bool isAuthenticated = false;
        public static MobileServiceSQLiteStore store = new MobileServiceSQLiteStore("localstore18.db");
        internal static Frame frame;
           

       /* public static MobileServiceClient MobileService = new MobileServiceClient(
          "http://localhost:58704"
);*/
        // Use this constructor instead after publishing to the cloud
         public static MobileServiceClient MobileService = new MobileServiceClient(
           "https://gardenr2.azure-mobile.net/",
     "DMHwnJmHwPivFxaTWjDNXjzAxykHpq92"
        );
        private static LaunchActivatedEventArgs globale;

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

            store.DefineTable<Plant>();
            store.DefineTable<Taal>();
            store.DefineTable<Alarm>();
            store.DefineTable<Gebruiker>();
            store.DefineTable<NieuwsItem>();
            store.DefineTable<Models.Notificaties>();
            store.DefineTable<TuinObject>();
            store.DefineTable<TypeC>();
            store.DefineTable<Gardenr.Models.Instellingen>();
            //models die er neit in staan
            //constants todoitems tuinobjects
                }

        private void Channel_PushNotificationReceived(PushNotificationChannel sender, PushNotificationReceivedEventArgs args)
        {
            throw new NotImplementedException();
        }

        private async void InstallVoiceCommands()
        {
            try
            {
                var storageFile = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///GardenrCommands.xml"));
                await Windows.ApplicationModel.VoiceCommands.VoiceCommandDefinitionManager.InstallCommandDefinitionsFromStorageFileAsync(storageFile);
            }
            catch(Exception e)
            {
              
            }
           
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
                frame.Navigate(typeof(Catalogus));
            }
            else if (message.PageNumber == 2) // catalogus plant pagina
            {
                frame.Navigate(typeof(CatalogusPlant),message.SelectedPlant);
  
            }
            else if(message.PageNumber == 3) // contact pagina
            {
                frame.Navigate(typeof(Contact));
            }
            else if(message.PageNumber == 4) // instellingen pagina
            {
                frame.Navigate(typeof(Views.Instellingen));
            }
            else if (message.PageNumber == 5) //Notificaties pagina
            {
                frame.Navigate(typeof(Views.Notificaties), message.SelectedNotificatie);
            }
            else if(message.PageNumber == 6) // Notificaties bewerken pagina
            {
                frame.Navigate(typeof(NotificatiesBewerken), message.SelectedNotificatie);
            }
            else if (message.PageNumber == 7) // Plant bewerken pagina
            {
                frame.Navigate(typeof(PlantBewerken),message.SelectedTuinPlant);
            }
            else if(message.PageNumber == 8) // Profiel historiek pagina
            {
                frame.Navigate(typeof(Profiel_Historiek));
            }
            else if (message.PageNumber == 9) // profiel favorieten pagina
            {
                frame.Navigate(typeof(Profiel_Favorieten));
            }
            else if(message.PageNumber == 10) // profiel plantinfo pagina
            {
                frame.Navigate(typeof(Profiel));
            }
            else if(message.PageNumber == 11)//home page
            {
                rootFrame.Navigate(typeof(Shell));
            }
            else if (message.PageNumber == 12)//home page
            {
                frame.Navigate(typeof(Home));
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
                this.DebugSettings.EnableFrameRateCounter = false;
            }
#endif
            globale = e;

            Messenger.Default.Register<GoToPageMessage>(this, NavigateToPage);
   

            if (e.PreviousExecutionState != ApplicationExecutionState.Running)
            {
                bool loadState = (e.PreviousExecutionState == ApplicationExecutionState.Terminated);
                ExtendedSplash extendedSplash = new ExtendedSplash(e.SplashScreen, loadState);
                Window.Current.Content = extendedSplash;

            }
            // Ensure the current window is active
            Window.Current.Activate();
            InstallVoiceCommands();
        }

        public static void dsdo(){
            
                     Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

        rootFrame.NavigationFailed += OnNavigationFailed;

                if (globale.PreviousExecutionState == ApplicationExecutionState.Terminated)
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
                rootFrame.Navigate(typeof(Login), globale.Arguments);
            }

            GoToPageMessage message = new GoToPageMessage() { PageNumber = 11 };
            Messenger.Default.Send<GoToPageMessage>(message);
        }

        protected override void OnActivated(IActivatedEventArgs args)
        {
            // Windows Phone 8.1 requires you to handle the respose from the WebAuthenticationBroker.

    if (args.Kind == ActivationKind.WebAuthenticationBrokerContinuation)
    {
        // Completes the sign-in process started by LoginAsync.
        // Change 'MobileService' to the name of your MobileServiceClient instance. 
        
      //  App.MobileService.LoginComplete(args as WebAuthenticationBrokerContinuationEventArgs);
    }

            if (args.Kind == ActivationKind.VoiceCommand)
            {


                var commandArgs = args as VoiceCommandActivatedEventArgs;
                SpeechRecognitionResult result = commandArgs.Result;
                Type navigateToPageType;
                string voiceCommand = result.RulePath[0];
                string spokenText = result.Text;
                string navigationParameterString = string.Empty;

                switch (voiceCommand)
                {
                    case "showCatalog":
                        
                        navigationParameterString = string.Format("{0}|{1}|{2}", voiceCommand, "", spokenText);
                        
                        navigateToPageType = typeof(Catalogus);
                        break;
                    default:
                        navigateToPageType = typeof(MainPage);
                        break;
                }
                if (frame == null)
                {
                    frame = new Frame();
                    Window.Current.Content = frame;
                }

                frame.Navigate(navigateToPageType, navigationParameterString);
                Window.Current.Activate();

            }

        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        static void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
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
