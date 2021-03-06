﻿using Gardenr.Models;
using Gardenr.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Xml;
using Windows.Data.Xml.Dom;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Gardenr.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CatalogusPlant : Page
    {
        public CatalogusPlant()
        {
            this.InitializeComponent();
            dosomething();

            bool isHardwareButtonsAPIPresent =
       Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");
            if (isHardwareButtonsAPIPresent)
            {
                //IS MOBILE
                Puntjes.Margin = new Thickness(-15, 0, -15, 0);

            }
            else { }
        }
        private String t = "";
        private async void dosomething()
        {

            CatalogusPlantVM a = this.DataContext as CatalogusPlantVM;
            t = await a.CheckFavoriet();
            APPBAR.Label = t;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CatalogusPlantVM a = this.DataContext as CatalogusPlantVM;
            a.Plant = e.Parameter as Plant;
            a.Maaklist();
        }


        private void TextBlock_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            CatalogusPlantVM a = this.DataContext as CatalogusPlantVM;
            a.GoBack.Execute("iets");

        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CatalogusPlantVM a = this.DataContext as CatalogusPlantVM;
            a.GoBack.Execute("iets");
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            zend("ZaaiDiepte");

        }


        private void zend(String t)
        {
            // Clear all existing notifications
            ToastNotificationManager.History.Clear();

            var longTime = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("longtime");
            DateTimeOffset expiryTime = DateTime.Now.AddSeconds(10);
            string expiryTimeString = longTime.Format(expiryTime);

            Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            //Find the text component of the content
            Windows.Data.Xml.Dom.XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");

            // Set the text on the toast. 
            // The first line of text in the ToastText02 template is treated as header text, and will be bold.
            toastTextElements[0].AppendChild(toastXml.CreateTextNode("Info"));
            toastTextElements[1].AppendChild(toastXml.CreateTextNode(t));

            // Set the duration on the toast
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((Windows.Data.Xml.Dom.XmlElement)toastNode).SetAttribute("duration", "long");

            // Create the actual toast object using this toast specification.
            ToastNotification toast = new ToastNotification(toastXml);

            toast.ExpirationTime = expiryTime;

            // Send the toast.
            ToastNotificationManager.CreateToastNotifier().Show(toast);

        }

        private void Grid_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            zend("Afstand tussen");
        }

        private void Grid_Tapped_2(object sender, TappedRoutedEventArgs e)
        {
            zend("Afstand rij");
        }

        private void Grid_Tapped_3(object sender, TappedRoutedEventArgs e)
        {
            zend("Water geven");
        }

        private void Grid_Tapped_4(object sender, TappedRoutedEventArgs e)
        {
            zend("Dagen tot oogst");
        }

        private void Grid_Tapped_5(object sender, TappedRoutedEventArgs e)
        {
            zend("Dagen tot verplanten");
        }

        private void Grid_Tapped_6(object sender, TappedRoutedEventArgs e)
        {
            zend("Geschikt voor binnen");
        }

        private void Grid_Tapped_7(object sender, TappedRoutedEventArgs e)
        {
            zend("Geschikt voor buiten");
        }

        private async void APPBAR_Click(object sender, RoutedEventArgs e)
        {
            CatalogusPlantVM a = this.DataContext as CatalogusPlantVM;
            await a.AddFavo();
            if (t.Equals("Toevoegen aan favorieten"))
            {
                zend("Succesvol aan favorieten toegevoegd");
                APPBAR.Label = "Verwijder uit favorieten";
            }
            else {
                zend("Succesvol uit favorieten gehaald");
                APPBAR.Label = "Toevoegen aan favorieten";
            }
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            doiets();

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            doiets();
        }
        private void doiets()
        {
          bool isHardwareButtonsAPIPresent =
       Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");
        /*    Jan.Width = new GridLength(15);
            Feb.Width = new GridLength(15);
            Mar.Width = new GridLength(15);
            Apr.Width = new GridLength(15);
            Mei.Width = new GridLength(15);
            Jun.Width = new GridLength(15);
            Jul.Width = new GridLength(15);
            aug.Width = new GridLength(15);
            sep.Width = new GridLength(15);
            Okt.Width = new GridLength(15);
            Dec.Width = new GridLength(15);
            Nov.Width = new GridLength(15);*/
            if (isHardwareButtonsAPIPresent)
            {
                //IS MOBILE
                Double a = Window.Current.Bounds.Width;
                if (a > 1200)
                {
                    ROW2.Height = new GridLength(320);
                }
                else if (a > 800)
                {
                    ROW2.Height = new GridLength(200);
                   /* Jan.Width = new GridLength(20);
                    Feb.Width = new GridLength(20);
                    Mar.Width = new GridLength(20);
                    Apr.Width = new GridLength(20);
                    Mei.Width = new GridLength(20);
                    Jun.Width = new GridLength(20);
                    Jul.Width = new GridLength(20);
                    aug.Width = new GridLength(20);
                    sep.Width = new GridLength(20);
                    Okt.Width = new GridLength(20);
                    Dec.Width = new GridLength(20);
                    Nov.Width = new GridLength(20);*/
                }
                else {
                    ROW2.Height = new GridLength(150);
                   
                }


            }
            else {

                Double a = Window.Current.Bounds.Width;
                if (a > 1200)
                {
                    ROW2.Height = new GridLength(320);
                }
                else if (a > 800)
                {
                    ROW2.Height = new GridLength(220);
                }
                else {
                    ROW2.Height = new GridLength(200);
                }
            }
        }
    }
}
