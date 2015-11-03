﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Gardenr.Mesages;
using Gardenr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace Gardenr.UserClass
{
    class PlantBewerkenVM : ViewModelBase
    {
        //classe voor vanuit profiel een plant in de tuin te bewerken
        public PlantBewerkenVM()
        {
            SavePlant = new RelayCommand(SavePlantM);
            DeletePlant = new RelayCommand(DeletePlantM);
            AddFavorites = new RelayCommand(AddFavoritesM);
            SetPicture = new RelayCommand(SetPictureM);

            //optie
            AddNotification = new RelayCommand(AddNotificationM);
        }

        public TuinObject Plant {get;set;}

        protected void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.Parameter as TuinObject != null)
            {
                this.Plant = e.Parameter as TuinObject;
            }
        }

        public RelayCommand SavePlant { get; set; }
        public void SavePlantM()
        {

        }
        public RelayCommand DeletePlant { get; set; }
        public void DeletePlantM()
        {

        }
        public RelayCommand AddFavorites { get; set; }
        public void AddFavoritesM()
        {
            //eerst plant opslaan
        }
        public RelayCommand SetPicture { get; set; }
        public void SetPictureM()
        {
            //openfiledialog bladibla
            //database aanpassen
        }
        public RelayCommand GoBack { get; set; }
        public void GoBackM()
        {
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 10};//voorlopig nog opsplitsing tussen huidig/fav/geschiedenigs pag 8-9-10
            Messenger.Default.Send<GoToPageMessage>(message);
        }


        //mss insteken
        public RelayCommand AddNotification { get; set; }
        public void AddNotificationM()
        {
            //eers tmoet plant opgeslaan worden
            //naar notificatiepagina gaan 
            //en plant meegeven al sparameter
        }
         
    }
}
