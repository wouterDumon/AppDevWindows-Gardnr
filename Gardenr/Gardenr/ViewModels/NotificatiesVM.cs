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
    class NotificatiesVM
    {
        public NotificatiesVM()
        {
            StartupGetItems();
            AddNotificatie = new RelayCommand(AddNotificatieM);
            BewerkNotificatie = new RelayCommand(BewerkNotificatieM);
            DeleteNotificatie = new RelayCommand(DeleteNotificatieM);
        }
        private INotificatiesRepository repoNotification = SimpleIoc.Default.GetInstance<INotificatiesRepository>();

        public ObservableCollection<Notificaties> IngesteldeNotificaties { get; set; }

        public Notificaties SelectedNotificatie { get; set; }

        public RelayCommand AddNotificatie { get; set; }
        public RelayCommand BewerkNotificatie { get; set; }
        public RelayCommand DeleteNotificatie { get; set; }
        
        public void AddNotificatieM()
        {
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 6};
            Messenger.Default.Send<GoToPageMessage>(message);
        }
        public void BewerkNotificatieM()
        {
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 6, SelectedNotificatie = SelectedNotificatie };
            Messenger.Default.Send<GoToPageMessage>(message);
        }
        public void DeleteNotificatieM()
        {
            
        }

        public async void StartupGetItems()
        {
            IngesteldeNotificaties = await repoNotification.GetNotificaties();
        }

    }
}
