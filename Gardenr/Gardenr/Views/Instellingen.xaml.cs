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
    public sealed partial class Instellingen : Page
    {
        public Instellingen()
        {
            this.InitializeComponent();
        }

        private void toggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            c();
        }

        private void ToggleSwitch_Toggled_1(object sender, RoutedEventArgs e)
        {
            c();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            c();
        }
        private void c() {
            InstellingenVM i = this.DataContext as InstellingenVM;
            i.SaveSettings.Execute(""); 
        }
    }
}
