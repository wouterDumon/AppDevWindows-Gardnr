﻿using Gardenr.ViewModels;
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
    public sealed partial class Profiel_Favorieten : Page
    {
        public Profiel_Favorieten()
        {
            this.InitializeComponent();
           
#if (!DEBUG)
                    //kijken of release > ADS MOGEN NIET IN TEST GEBRUIKT WORDEN
               bool isHardwareButtonsAPIPresent =
        Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");
            if (isHardwareButtonsAPIPresent)
            {
                //IS MOBILE

                add.AdUnitId = App.MobileADID;
                add.ApplicationId = App.MobileappID;
            }
            else {
                //is desktop
                add.AdUnitId = App.adID;
                add.ApplicationId = App.appID;
            }
           
#endif
        }

        private void ListItems_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ProfielVM a = this.DataContext as ProfielVM;
            a.GoToPlant.Execute("iets");
        }

        private void Position_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ProfielVM a = this.DataContext as ProfielVM;
            FrameworkElement parent = (FrameworkElement)((Button)sender).Parent;
            string parent_name = parent.Tag.ToString();

            a.UnfavoriteM(parent_name);
        }
    }
}
