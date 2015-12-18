using Gardenr.Mesages;
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
    public sealed partial class NotificatiesBewerken : Page
    {
        public NotificatiesBewerken()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NotificatiesBewerkenVM a = this.DataContext as NotificatiesBewerkenVM;
            NotificatieMessage temp = e.Parameter as Gardenr.Mesages.NotificatieMessage;
            if(temp != null)
            {
                a.BewNotificatie = temp.SelectedNotificatie;
                a.GegevenTuinObject = temp.SelectedTuinPlant;
            }
            else
            {
                a.BewNotificatie = null;
                a.GegevenTuinObject = null;
            }
        
            a.OnMessageGet();
        }

        private void slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }
    }
}
