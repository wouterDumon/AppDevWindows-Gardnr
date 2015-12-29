using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Gardenr.Mesages;
using Gardenr.Models;
using Gardenr.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private int zitindb = 0;
        private Tuin objectindb;
        public async Task<String> CheckFavoriet()
        {
            ObservableCollection<Tuin> tuin = await repotuin.GetTOs(App.Gebruiker.ID);
            foreach (Tuin to in tuin) {
                if (to.Aantal == 0) {
                    if (to.Plant.ID.Equals(Plant.ID))
                    {
                        //ZIT IN DB
                        zitindb = 1;
                        objectindb = to;
                        if (to.favoriet)
                        {
                            return "Verwijder uit favorieten";
                        }
                        else {
                            return "Toevoegen aan favorieten";
                        }
                    }

                }        
            }
            return "Toevoegen aan favorieten";
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


            TuinObject t = new TuinObject();
            t.gebruikerID = App.Gebruiker.ID;
            t.PlantenID = Plant.ID;
            t.LaatstWater = "" + DateTime.Now;
            t.favoriet = true;
            t.extra = "";
            t.Aantal = 0;
            t.historiek = false;
            t.plantDatum = "" + DateTime.Now;
            t.NotificationID = "";

            repotuin.AddTO(t);

            //ZEND TOAST
        //    GoToPageMessage message = new GoToPageMessage() { PageNumber = 9 };
         //   Messenger.Default.Send<GoToPageMessage>(message);
        }
        public async Task<int> AddFavo()
        {
            if (zitindb == 0)
            {
                TuinObject t = new TuinObject();
                t.gebruikerID = App.Gebruiker.ID;
                t.PlantenID = Plant.ID;
                t.LaatstWater = "" + DateTime.Now;
                t.favoriet = true;
                t.extra = "";
                t.Aantal = 0;
                t.historiek = false;
                t.plantDatum = "" + DateTime.Now;
                t.NotificationID = "";

                await repotuin.AddFAV(t);
                return 1;
            }
            else {
                TuinObject t = new TuinObject();
                t.gebruikerID = App.Gebruiker.ID;
                t.PlantenID = objectindb.Plant.ID;
                t.LaatstWater =objectindb.LaatstWater;
                t.ID = objectindb.ID;
                bool b = true;
                if (objectindb.favoriet) { b = false; }
                t.favoriet = b;
                t.extra = objectindb.extra;
                t.Aantal = objectindb.Aantal;
                t.historiek = objectindb.historiek;
                t.plantDatum = objectindb.plantDatum;
                t.NotificationID = "";
                await repotuin.AdjustFAV(t);
                return 1;
            }
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
