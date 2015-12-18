using Gardenr.helper;
using Gardenr.ViewModels;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Gardenr.Views
{
    partial class ExtendedSplash
    {
        internal Rect splashImageRect; // Rect to store splash screen image coordinates.
        internal bool dismissed = false; // Variable to track splash screen dismissal status.
        internal Frame rootFrame;

        private SplashScreen splash; // Variable to hold the splash screen object.
        private double ScaleFactor; //Variable to hold the device scale factor (use to determine phone screen resolution)

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

        public ExtendedSplash(SplashScreen splashscreen, bool loadState)
        {
            InitializeComponent();
            setuptitle();
            LoginVM vm = this.DataContext as LoginVM;
            STARTUP(vm);

          //  LearnMoreButton.Click += new RoutedEventHandler(LearnMoreButton_Click);
            // Listen for window resize events to reposition the extended splash screen image accordingly.
            // This is important to ensure that the extended splash screen is formatted properly in response to snapping, unsnapping, rotation, etc...
            Window.Current.SizeChanged += new WindowSizeChangedEventHandler(ExtendedSplash_OnResize);

            ScaleFactor = (double)DisplayInformation.GetForCurrentView().ResolutionScale / 100;

            splash = splashscreen;

            if (splash != null)
            {
                // Register an event handler to be executed when the splash screen has been dismissed.
                splash.Dismissed += new TypedEventHandler<SplashScreen, Object>(DismissedEventHandler);

                // Retrieve the window coordinates of the splash screen image.
                splashImageRect = splash.ImageLocation;
                PositionImage();
            }

            // Create a Frame to act as the navigation context
            rootFrame = new Frame();

            // Restore the saved session state if necessary
            RestoreStateAsync(loadState);
        }

        private async void STARTUP(LoginVM vm)
        {
            stack1.Visibility = Visibility.Collapsed;
            stack0.Visibility = Visibility.Visible;
            stack2.Visibility = Visibility.Collapsed;
            await vm.watchlogin();
         
            stack0.Visibility = Visibility.Collapsed;
            stack1.Visibility = Visibility.Visible;
        }

        async void RestoreStateAsync(bool loadState)
        {
            if (loadState)
                await SuspensionManager.RestoreAsync();

            // Normally you should start the time consuming task asynchronously here and
            // dismiss the extended splash screen in the completed handler of that task
            // This sample dismisses extended splash screen  in the handler for "Learn More" button for demonstration
        }

        // Position the extended splash screen image in the same location as the system splash screen image.
        void PositionImage()
        {
            extendedSplashImage.SetValue(Canvas.LeftProperty, splashImageRect.Left);
            extendedSplashImage.SetValue(Canvas.TopProperty, splashImageRect.Top);
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                extendedSplashImage.Height = splashImageRect.Height / ScaleFactor;
                extendedSplashImage.Width = splashImageRect.Width / ScaleFactor;
            }
            else
            {
                extendedSplashImage.Height = splashImageRect.Height;
                extendedSplashImage.Width = splashImageRect.Width;
            }
        }

        void ExtendedSplash_OnResize(Object sender, WindowSizeChangedEventArgs e)
        {
            // Safely update the extended splash screen image coordinates. This function will be fired in response to snapping, unsnapping, rotation, etc...
            if (splash != null)
            {
                // Update the coordinates of the splash screen image.
                splashImageRect = splash.ImageLocation;
                PositionImage();
            }
        }

       /* void LearnMoreButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to mainpage
            rootFrame.Navigate(typeof(MainPage));

            // Set extended splash info on main page
            ((MainPage)rootFrame.Content).SetExtendedSplashInfo(splashImageRect, dismissed);

            // Place the frame in the current Window
            Window.Current.Content = rootFrame;
        }*/

        // Include code to be executed when the system has transitioned from the splash screen to the extended splash screen (application's first view).
        void DismissedEventHandler(SplashScreen sender, object e)
        {
            dismissed = true;

            // Navigate away from the app's extended splash screen after completing setup operations here...
            // This sample navigates away from the extended splash screen when the "Learn More" button is clicked.
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginVM vm = this.DataContext as LoginVM;
            vm.Testing.Execute("");
            stack1.Visibility = Visibility.Collapsed;
            stack2.Visibility = Visibility.Visible;

        }
    }
}