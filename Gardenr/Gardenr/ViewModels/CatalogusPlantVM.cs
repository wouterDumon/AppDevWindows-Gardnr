using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Gardenr.Mesages;
using Gardenr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Gardenr.ViewModels
{
    class CatalogusPlantVM : ViewModelBase
    {
        public CatalogusPlantVM()
        {
            GoBack = new RelayCommand(GoBackM);
            AddFavorieten = new RelayCommand(AddFavorietenM);
            AddGarden = new RelayCommand(AddGardM);
            MakeNotification = new RelayCommand(MakeNotificationM);
        }

        public  void OnNavigatedTo(NavigationEventArgs e)
        {
            this.plant = e.Parameter as Plant;
        }

        public Plant plant { get; set; }

        public RelayCommand GoBack{get; set;}
        public RelayCommand AddFavorieten { get; set; }
        public RelayCommand AddGarden { get; set; }
        public RelayCommand MakeNotification { get; set; }

        public void GoBackM()
        {
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 1 };
            Messenger.Default.Send<GoToPageMessage>(message);
        }
        public void AddFavorietenM()
        {
            
        }
        public void AddGardM()
        {

        }
        public void MakeNotificationM()
        {

        }
    }
}
