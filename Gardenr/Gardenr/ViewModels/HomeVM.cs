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
    class HomeVM : ViewModelBase
    {
        public HomeVM()
        {
            StartUpGetItems();
            naam = App.Gebruiker.Voornaam + " " + App.Gebruiker.Naam;
            VieuwNotification = new RelayCommand(VieuwNotificationM);
            VieuwNieuwsItem = new RelayCommand(VieuwNieuwsItemM);
        }

        private string naam { get; set; }

       
        private INotificatiesRepository repoNotification = SimpleIoc.Default.GetInstance<INotificatiesRepository>();

        private ObservableCollection<Notificaties> _notificaties;
        public ObservableCollection<Notificaties> Notificaties
        {
            get
            {
                return _notificaties;
            }
            set
            {
                _notificaties = value; OnPropertyChanged("Notificaties");
            }
        }

        private Notificaties _selectedNotificatie;
        public Notificaties SelectedNotificatie
        {
            get { return _selectedNotificatie; }
            set { _selectedNotificatie = value; OnPropertyChanged("SelectedNotificatie"); }
        }

        //misschiencommands voor naar notificatie detail te gaan
        private INieuwsRepository repoNieuws = SimpleIoc.Default.GetInstance<INieuwsRepository>();

        private ObservableCollection<NieuwsItem> _nieuwsItems;
        public ObservableCollection<NieuwsItem> NieuwsItems
        {
            get { return _nieuwsItems; }
            set { _nieuwsItems = value; OnPropertyChanged("NieuwsItems"); }
        }
        private NieuwsItem _selectedNieuwsItem;
        public NieuwsItem SelectedNieuwsItem
        {
            get { return _selectedNieuwsItem; }
            set { _selectedNieuwsItem = value; OnPropertyChanged("SelectedNieuwsItem"); }
        }

        public async void StartUpGetItems()
        {
            //nog doen zodanig dat de notificaties enkel van de ingelogd gebruiker ingegeven worden

            Notificaties = await repoNotification.GetNotificaties();
            NieuwsItems = await repoNieuws.GetNewsItems();
        }



        public RelayCommand VieuwNotification { get; set; }
        public void VieuwNotificationM()
        {
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 5, SelectedNotificatie = SelectedNotificatie };
            Messenger.Default.Send<GoToPageMessage>(message);
        }
        public RelayCommand VieuwNieuwsItem { get; set; }
        public void VieuwNieuwsItemM()
        {

        }
    }
}
