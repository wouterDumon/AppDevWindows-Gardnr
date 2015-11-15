﻿using GalaSoft.MvvmLight;
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
            AddTuinObject = new RelayCommand(AddTuinObjectM);
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
        public ObservableCollection<Tuin> FavorieetenPlant
        {
            get { return _favorietenPlant; }
            set { _favorietenPlant = value; OnPropertyChanged("HistoriekPlant"); }
        }

        public string SearchTerm { get; set; }

        public RelayCommand GoToTuinObject { get; set; }
        public void TuinObjectDetail()
        {//pag 7
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 7, SelectedTuinPlant = SelectedPlant };
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
                foreach(Tuin tplant in TuinPlanten)
                {
                    if(tplant.favoriet)
                    {
                        _favorietenPlant.Add(tplant);
                        //checken of in historiek of nietook
                    }
                }
            }
            catch (Exception ex) { }
            }
    }

}
