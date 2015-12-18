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
using Windows.UI.Xaml.Navigation;

namespace Gardenr.ViewModels
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
            GoBack = new RelayCommand(GoBackM);
            //optie
            AddNotification = new RelayCommand(AddNotificationM);
            GoNotification = new RelayCommand(GoNotificationM);

          
        }

        private DateTime _oogstDatum;
        public DateTime OogstDatum
        {
            get { return _oogstDatum; }
            set { _oogstDatum = value; OnPropertyChanged("OogstDatum"); }
        }


        public ITuinRepository repoTuin = SimpleIoc.Default.GetInstance<ITuinRepository>();

        private Tuin _teBewerkenTuin;
        public Tuin TeBewerkenTuin
        {
            get { return _teBewerkenTuin; }
            set
            {
                _teBewerkenTuin = value; OnPropertyChanged("TeBewerkenTuin");
                if (value != null)
                {
                    OogstDatum = DateTime.Parse(TeBewerkenTuin.plantDatum).AddDays(double.Parse(TeBewerkenTuin.Plant.DagenOogst));
                }
            }
        }

        private Tuin _selectedTuin;
        public Tuin SelectedTuin
        {
            get { return _selectedTuin; }
            set { _selectedTuin = value; OnPropertyChanged("SelectedTuin"); }
        }



        private ObservableCollection<Notificaties> _notificaties;
        public ObservableCollection<Notificaties> Notificaties
        {
            get { return _notificaties; }
            set { _notificaties = value; OnPropertyChanged("Notificaties"); }
        }
        private Notificaties _selectedNotificatie;
        public Notificaties SelectedNotificatie
        {
            get { return _selectedNotificatie; }
            set { _selectedNotificatie = value; OnPropertyChanged("SelectedNotificatie"); }
        }

       

        public RelayCommand SavePlant { get; set; }
        public void SavePlantM()
        {
            repoTuin.AdjustTO(TeBewerkenTuin);

            GoToPageMessage message = new GoToPageMessage() { PageNumber = 10 };//voorlopig nog opsplitsing tussen huidig/fav/geschiedenigs pag 8-9-10
            Messenger.Default.Send<GoToPageMessage>(message);
        }
        public RelayCommand DeletePlant { get; set; }
        public void DeletePlantM()
        {
            repoTuin.DeleteTO(TeBewerkenTuin);
        }
        public RelayCommand AddFavorites { get; set; }
        public void AddFavoritesM()
        {
            TeBewerkenTuin.favoriet = true;
            repoTuin.AdjustTO(TeBewerkenTuin);
            //eerst plant opslaan

            GoToPageMessage message = new GoToPageMessage() { PageNumber = 10 };//voorlopig nog opsplitsing tussen huidig/fav/geschiedenigs pag 8-9-10
            Messenger.Default.Send<GoToPageMessage>(message);
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
            NotificatieMessage temp = new NotificatieMessage() { SelectedTuinPlant = TeBewerkenTuin };
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 6 , Notificatie = temp };
            Messenger.Default.Send<GoToPageMessage>(message);
        }
         public RelayCommand GoNotification { get; set; }
        public void GoNotificationM()
        {
            NotificatieMessage temp = new NotificatieMessage() { SelectedTuinPlant = TeBewerkenTuin ,SelectedNotificatie = SelectedNotificatie};
           
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 5, Notificatie = temp  };
            Messenger.Default.Send<GoToPageMessage>(message);
        }

        public async void Startup()
        {

        }
    }
}
