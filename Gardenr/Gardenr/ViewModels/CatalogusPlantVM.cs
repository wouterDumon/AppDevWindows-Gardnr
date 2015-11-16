using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Gardenr.Mesages;
using Gardenr.Models;
using Gardenr.Repositories;
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



        public Plant plant { get; set; }

        public RelayCommand GoBack { get; set; }
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
        public  void AddGardM()
        {
            TuinObject t = new TuinObject();
            t.gebruikerID = App.Gebruiker.ID;
            t.PlantenID = plant.ID;
            t.LaatstWater = "" + DateTime.Now;
            t.favoriet = false;
            t.extra = "";
            t.Aantal = 1;
            t.historiek = false;
            t.plantDatum = "" + DateTime.Now;
            t.NotificationID = "";
            
           repotuin.AddTO(t);
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 10};
            Messenger.Default.Send<GoToPageMessage>(message);
        }
             private ITuinRepository repotuin = SimpleIoc.Default.GetInstance<ITuinRepository>();
    

    public void MakeNotificationM()
        {

        }
    }
}
