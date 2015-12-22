using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Gardenr.Mesages;
using Gardenr.Models;
using Gardenr.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
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


        private Plant _plant;
        public Plant Plant {
            get { return _plant; }
            set{
                _plant = value;
                PlantBegin = DateToMonth(value.PlantBegin);
                PlantLengte = DateToMonth(value.PlantEinde) - PlantBegin;
                PlantBegin++;
                ZaaiBegin = DateToMonth(value.ZaaiBegin);
                ZaaiLengte = DateToMonth(value.ZaaiEinde) - ZaaiBegin;
                ZaaiBegin++;
                OogstBegin = DateToMonth(value.OogstBegin);
                OogstLengte = DateToMonth(value.OogstEinde) - OogstBegin;
                OogstBegin++;
                OnPropertyChanged("Plant");
            }
        }

        public int DateToMonth(String datum)
        {
            //omdat ik te lui was om het telkes te typen wouter
            try
            {
                return DateTime.ParseExact(datum,"dd/MM/yyyy",CultureInfo.InvariantCulture).Month;
            }
            catch(Exception e)
            {
                Exception mijnexceptie = e;
                return 0;
            }
           
        }

        public RelayCommand GoBack { get; set; }
        public RelayCommand AddFavorieten { get; set; }
        public RelayCommand AddGarden { get; set; }
        public RelayCommand MakeNotification { get; set; }


        public int ZaaiBegin { get; set; }
        public int ZaaiLengte { get; set; }
        public int PlantBegin { get; set; }
        public int PlantLengte { get; set; }
        public int OogstBegin { get; set; }
        public int OogstLengte { get; set; }

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
            t.PlantenID = Plant.ID;
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
