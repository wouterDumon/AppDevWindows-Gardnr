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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.ViewModels
{
    class ProfielVM : ViewModelBase
    {
        //menu navigatie huidig/favorieten/geschidenis zit er nog niet in
        public ProfielVM()
        {
            StartupGetItems();
            GoToTuinObject = new RelayCommand(TuinObjectDetail);
            GoToPlant = new RelayCommand(PlantDetail);
            AddTuinObject = new RelayCommand(AddTuinObjectM);
            GoHuiding = new RelayCommand(GoHuidigM);
            GoHistoriek = new RelayCommand(GoHistoriekM);
            GoFavoriet = new RelayCommand(GoFavorietM);
            goadd = new RelayCommand(goaddM);
        }

        public void goaddM()
        {
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 1 };
            Messenger.Default.Send<GoToPageMessage>(message);
        }

        public ITuinRepository repoTuin = SimpleIoc.Default.GetInstance<ITuinRepository>();

     


        private ObservableCollection<Tuin> _tuinplanten;
        public ObservableCollection<Tuin> TuinPlanten
        {
            get { return _tuinplanten; }
            set { _tuinplanten = value; OnPropertyChanged("TuinPlanten"); }
        }

        private Tuin _selectedPlant;
        public Tuin SelectedPlant
        { 
            get { return _selectedPlant; }
            set { _selectedPlant = value;  OnPropertyChanged("SelectedPland"); }
        }

        private ObservableCollection<Tuin> _historiekPlant;
        public ObservableCollection<Tuin> HistoriekPlant
        {
            get { return _historiekPlant; }
            set { _historiekPlant = value; OnPropertyChanged("HistoriekPlant"); }
        }

        private ObservableCollection<Tuin> _favorietenPlant;
        public RelayCommand goadd { get; set; }

        public ObservableCollection<Tuin> FavorietenPlant
        {
            get { return _favorietenPlant; }
            set { _favorietenPlant = value; OnPropertyChanged("FavorietenPlant"); }
        }

        public string SearchTerm { get; set; }

        public RelayCommand GoToTuinObject { get; set; }
        public void TuinObjectDetail()
        {//pag 7
            if (SelectedPlant == null) return;
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 7, SelectedTuinPlant = SelectedPlant };
            Messenger.Default.Send<GoToPageMessage>(message);
        }

        public RelayCommand GoToPlant { get; set; }
        public void PlantDetail()
        {//pag 2
            if (SelectedPlant == null) return;
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 2, SelectedPlant = SelectedPlant.Plant };
            Messenger.Default.Send<GoToPageMessage>(message);
        }


        public RelayCommand GoHuiding { get; set; }
        public void GoHuidigM()
        {

            GoToPageMessage message = new GoToPageMessage() { PageNumber = 10};
            Messenger.Default.Send<GoToPageMessage>(message);
        }
        public RelayCommand GoHistoriek { get; set; }
        public void GoHistoriekM()
        {
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 8};
            Messenger.Default.Send<GoToPageMessage>(message);
        }
        public RelayCommand GoFavoriet { get; set; }
        public void GoFavorietM()
        {
            GoToPageMessage message = new GoToPageMessage() { PageNumber =9};
            Messenger.Default.Send<GoToPageMessage>(message);
        }

        //zit in menu item
        public RelayCommand AddTuinObject { get; set; }
        public void AddTuinObjectM()
        {
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 1};
            Messenger.Default.Send<GoToPageMessage>(message);
        }


        //voor eventueel in het profiel in het tab favorieten bepaalde planten
        //te kunnen unfavoriten
        public RelayCommand NoMoreFav { get; set; }
        public void NoMoveFavM()
        {
            //aanduiden dat plant niet meer een favoriet is
        }



        public async  void StartupGetItems()
        {
            //planten ophalen van de user
            try
            {
                TuinPlanten = await repoTuin.GetTOs(App.Gebruiker.ID);
                FavorietenPlant = new ObservableCollection<Tuin>();
                HistoriekPlant = new ObservableCollection<Tuin>();
                foreach(Tuin tplant in TuinPlanten)
                {
                    if(tplant.favoriet==true)
                    {
                        if (FavorietenPlant.Contains(tplant)) { }
                        else
                        {
                            FavorietenPlant.Add(tplant);
                        }
                        //checken of in historiek of nietook
                    }
                    if (tplant.historiek == true) {
                        HistoriekPlant.Add(tplant);
                    }
                    
                }
                //HistoriekPlant = TuinPlanten;
            }
            catch (Exception ex) { Exception mijnexceptie = ex; }
            }
    }

}
