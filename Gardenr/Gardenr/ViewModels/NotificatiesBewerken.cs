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

            Startup();

           
    }

        private bool nieuwNotificatie{get;set;}

        private DateTimeOffset _date;
        public DateTimeOffset Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged("Date"); }
        }
       

        private Alarm _notAlarm;
        public Alarm NotAlarm
        {
            get { return _notAlarm; }
            set {
                _notAlarm = value;
                OnPropertyChanged("NotAlarm");
            }
        }

        private ObservableCollection<TypeC> _notificatieTypes;
        public ObservableCollection<TypeC> NotificatieTypes
        {
            get { return _notificatieTypes; }
            set { _notificatieTypes = value; OnPropertyChanged("NotificatieTypes"); }
        }

     

        private Notificaties _BewNotificatie;
        public Notificaties BewNotificatie
        {
            get { return _BewNotificatie; }
            set { _BewNotificatie = value; OnMessageGet(); OnPropertyChanged("BewNotificatie"); }
        }

        private Tuin _gegevenTuinObject;
        public Tuin GegevenTuinObject
        {
            get { return _gegevenTuinObject; }
            set { _gegevenTuinObject = value; }
        }

        public RelayCommand SaveSettings { get; set; }
        private INotificatiesRepository reponotif = SimpleIoc.Default.GetInstance<INotificatiesRepository>();
        private ITypeRepository repoType = SimpleIoc.Default.GetInstance<ITypeRepository>();
        private IAlarmRepository repoAlarm = SimpleIoc.Default.GetInstance<IAlarmRepository>();

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
                repoAlarm.AdjustNewsItem(NotAlarm);
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

        public async void Startup()
        {
            NotificatieTypes = await repoType.GetTypes();
           

        }
        public async void OnMessageGet()
        {
            if(BewNotificatie== null)
            {
                nieuwNotificatie = true;
                BewNotificatie = new Notificaties();
                BewNotificatie.GebruikerID = App.Gebruiker.ID;
                BewNotificatie.Omschrijving = "kkkkkk";
                BewNotificatie.AlarmID = "1";
                BewNotificatie.datum = "01/01/2015";
                BewNotificatie.TypeID = "1";
                NotAlarm = await repoAlarm.GetAlarmBID(BewNotificatie.AlarmID);
                nieuwNotificatie = true;
            }
            else
            {
                NotAlarm = await repoAlarm.GetAlarmBID(BewNotificatie.AlarmID);

                string[] temp= BewNotificatie.datum.Split('/');
            
                DateTime date = new DateTime(int.Parse(temp[2]), int.Parse(temp[1]), int.Parse(temp[0]));
                Date = new DateTimeOffset(date);
                nieuwNotificatie = false;
            }
           
        }

    }
}
