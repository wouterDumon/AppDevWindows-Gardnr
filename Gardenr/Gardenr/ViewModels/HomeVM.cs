using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
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
        public Notificaties SelectedNotificatie {
            get { return _selectedNotificatie; }
            set { _selectedNotificatie = value; OnPropertyChanged("SelectedNotificatie"); }
        }

        //misschiencommands voor naar notificatie detail te gaan
        private INieuwsRepository repoNieuws = SimpleIoc.Default.GetInstance<INieuwsRepository>();
        public ObservableCollection<NieuwsItem> NieuwsItems { get; set; }
        public NieuwsItem SelectedNieuwsItem { get; set; }

        public async void StartUpGetItems()
        {
            Notificaties = await repoNotification.GetNotificaties();
       //     NieuwsItems = await repoNieuws.GetNewsItems();
        }



        public RelayCommand VieuwNotification { get; set; }
        public void VieuwNotificationM()
        {

        }
        public RelayCommand VieuwNieuwsItem { get; set; }
        public void VieuwNieuwsItemM()
        {

        }
    }
}
