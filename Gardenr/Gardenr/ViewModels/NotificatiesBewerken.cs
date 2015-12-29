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

        private Plant _notificatiePlant;
        public Plant NotificatiePlant
        {
            get { return _notificatiePlant; }
            set { _notificatiePlant = value; OnPropertyChanged("NotificatiePlant"); }
        }

        private ObservableCollection<TypeC> _notificatieTypes;
        public ObservableCollection<TypeC> NotificatieTypes
        {
            get { return _notificatieTypes; }
            set { _notificatieTypes = value; OnPropertyChanged("NotificatieTypes"); }
        }

        private TypeC _selectedType;
        public TypeC SelectedType
        {
            get { return _selectedType; }
            set { _selectedType = value; OnPropertyChanged("SelectedType"); }
        }

        private Notificaties _BewNotificatie;
        public Notificaties BewNotificatie
        {
            get { return _BewNotificatie; }
            set { _BewNotificatie = value;/* OnMessageGet(); */OnPropertyChanged("BewNotificatie"); }
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
        private ITuinRepository repoTuin = SimpleIoc.Default.GetInstance<ITuinRepository>();
        private IPlantRepository repoPlant = SimpleIoc.Default.GetInstance<IPlantRepository>();

        public async void SaveSettingsM()
        {
            if (nieuwNotificatie)
            {
                BewNotificatie.TypeID = SelectedType.ID;
                BewNotificatie.datum = Date.Day + "/" + Date.Month+"/" + Date.Year;

                if (GegevenTuinObject != null)
                {
                    BewNotificatie.PlantID = GegevenTuinObject.Plant.ID;
                    NotAlarm.Activate = true;
                    await repoAlarm.AddNewsItem(NotAlarm);
                    BewNotificatie.AlarmID = NotAlarm.ID;

                    await reponotif.AddNotificatie(BewNotificatie);

                    if (GegevenTuinObject.Notificaties == null)
                    {
                        GegevenTuinObject.Notificaties = new ObservableCollection<Notificaties>();
                        GegevenTuinObject.Notificaties.Add(BewNotificatie);
                    }
                    else
                    {
                        GegevenTuinObject.Notificaties.Add(BewNotificatie);
                    }

                    
                    repoTuin.AdjustTO(GegevenTuinObject);

                  
                    GoToPageMessage message = new GoToPageMessage() { PageNumber = 7, SelectedTuinPlant = GegevenTuinObject };
                    Messenger.Default.Send<GoToPageMessage>(message);
                }
                else
                {
                    NotAlarm.Activate = true;
                    await repoAlarm.AddNewsItem(NotAlarm);
                    BewNotificatie.AlarmID = NotAlarm.ID;
                    await reponotif.AddNotificatie(BewNotificatie);
                    GoToPageMessage message1 = new GoToPageMessage() { PageNumber = 12 };
                    Messenger.Default.Send<GoToPageMessage>(message1);
                }
                
            }
            else
            {
             
               
                if(NotAlarm.ID == null)
                {
                    NotAlarm.Activate = true;
                    await repoAlarm.AddNewsItem(NotAlarm);
                    BewNotificatie.AlarmID = NotAlarm.ID;
                }
                else
                {
                    NotAlarm.Activate = true;
                    repoAlarm.AdjustNewsItem(NotAlarm);
                }
                BewNotificatie.datum = Date.Day + "/" + Date.Month + "/" + Date.Year;
                BewNotificatie.TypeID = SelectedType.ID;
                reponotif.AdjustNotificatie(BewNotificatie);

                NotificatieMessage temp = new NotificatieMessage() { SelectedNotificatie = BewNotificatie };

                GoToPageMessage message = new GoToPageMessage() { PageNumber = 5, Notificatie = temp };
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
            foreach (var item in NotificatieTypes)
            {
                if (item.ID == BewNotificatie.TypeID)
                {
                    SelectedType = item;
                }
            }


        }
        public async void OnMessageGet()
        {
            if(GegevenTuinObject!=null)
            {
                NotificatiePlant = GegevenTuinObject.Plant;
            }
            if(BewNotificatie== null)
            {
                NotAlarm = new Alarm();

                
                BewNotificatie = new Notificaties();
                BewNotificatie.GebruikerID = App.Gebruiker.ID;
                BewNotificatie.Omschrijving = "";
                BewNotificatie.AlarmID = "1";
                DateTime vandaag = DateTime.Now;
                string datum = vandaag.Day + "/" + vandaag.Month + "/" + vandaag.Year;
                BewNotificatie.datum = datum;
                BewNotificatie.TypeID = "1";
                //if (NotificatieTypes.Count() != 0) {
                //    SelectedType = NotificatieTypes.ToList().First();

                //}
               
                nieuwNotificatie = true;

                string[] temp = BewNotificatie.datum.Split('/');
                Date = new DateTime(int.Parse(temp[2]), int.Parse(temp[1]), int.Parse(temp[0]));
            }
            else
            {
                NotAlarm = await repoAlarm.GetAlarmBID(BewNotificatie.AlarmID);
                if (BewNotificatie.PlantID != null)
                {
                    NotificatiePlant = await repoPlant.GetPlantById(BewNotificatie.PlantID);
                }
                if (NotAlarm == null)
                {
                    NotAlarm = new Alarm();
                    
                }

                string[] temp= BewNotificatie.datum.Split('/');
            
                DateTime date = new DateTime(int.Parse(temp[2]), int.Parse(temp[1]), int.Parse(temp[0]));
                Date = new DateTimeOffset(date);
                nieuwNotificatie = false;

                //fin type needed for dropdown list

                foreach (var item in NotificatieTypes)
                {
                    if (item.ID == BewNotificatie.TypeID)
                    {
                        SelectedType = item;
                    }
                }
            }
           
        } 
           
        

    }
}
