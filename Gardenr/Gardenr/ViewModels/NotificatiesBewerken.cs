﻿using GalaSoft.MvvmLight.Command;
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
using Windows.UI.Xaml.Navigation;

namespace Gardenr.ViewModels
{
    class NotificatiesBewerkenVM : ViewModelBase
    {
        public NotificatiesBewerkenVM()
        {
            SaveSettings = new RelayCommand(SaveSettingsM);
            DeleteNotificatie = new RelayCommand(DeleteNotificatieM);
            GoBack = new RelayCommand(GoBackM);
            DatePicker = new RelayCommand(DatePickerM);
            PickImage = new RelayCommand(PickImageM);


            if (BewNotificatie == null)
            {
                nieuwNotificatie = true;
            }
            else
            {
                nieuwNotificatie = false;
            }

        }

        private bool nieuwNotificatie{get;set;}

        private Notificaties _BewNotificatie;
        public Notificaties BewNotificatie
        {
            get { return _BewNotificatie; }
            set { _BewNotificatie = value; OnPropertyChanged("BewNotificatie"); }
        }

        private Tuin _gegevenTuinObject;
        public Tuin GegevenTuinObject
        {
            get { return _gegevenTuinObject; }
            set { _gegevenTuinObject = value; }
        }

        public RelayCommand SaveSettings { get; set; }
        private INotificatiesRepository reponotif = SimpleIoc.Default.GetInstance<INotificatiesRepository>();

        public void SaveSettingsM()
        {
            if (nieuwNotificatie)
            {
                if(GegevenTuinObject != null)
                {
                    BewNotificatie.PlantID = GegevenTuinObject.ID;
                    reponotif.AddNotificatie(BewNotificatie);
                    GoToPageMessage message = new GoToPageMessage() { PageNumber = 7, SelectedTuinPlant = GegevenTuinObject };
                    Messenger.Default.Send<GoToPageMessage>(message);
                }

                reponotif.AddNotificatie(BewNotificatie);
                GoToPageMessage message1 = new GoToPageMessage() { PageNumber = 12 };
                Messenger.Default.Send<GoToPageMessage>(message1);
            }
            else
            {
                reponotif.AdjustNotificatie(BewNotificatie);
                GoToPageMessage message = new GoToPageMessage() { PageNumber = 6, SelectedNotificatie = BewNotificatie };
                Messenger.Default.Send<GoToPageMessage>(message);
            }

           
        }
        public RelayCommand DeleteNotificatie { get; set; }
        public void DeleteNotificatieM()
        {

        }
        public RelayCommand GoBack { get; set; }
        public void GoBackM()
        {

        }
        public RelayCommand DatePicker { get; set; }
        public void DatePickerM()
        {

        }
        public RelayCommand PickImage { get; set; }
        public void PickImageM()
        {

        }

    }
}
