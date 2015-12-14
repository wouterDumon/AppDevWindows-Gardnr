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
    class NotificatiesVM : ViewModelBase
    {
        public NotificatiesVM()
        {
            
            AddNotificatie = new RelayCommand(AddNotificatieM);
            BewerkNotificatie = new RelayCommand(BewerkNotificatieM);
            DeleteNotificatie = new RelayCommand(DeleteNotificatieM);
           
        }


        private TypeC _notificatieType;
        public TypeC NotificatieType
        {
            get { return _notificatieType; }
            set { _notificatieType = value; OnPropertyChanged("NotificatieType"); }
        }


        private Notificaties _ingestelde;

        public Notificaties IngesteldeNotificaties
        {
            get { return _ingestelde; }
            set { _ingestelde = value; GetTypes(); OnPropertyChanged("IngesteldeNotificaties"); }
        }


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
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 6, SelectedNotificatie = IngesteldeNotificaties };
            Messenger.Default.Send<GoToPageMessage>(message);
        }
        private INotificatiesRepository reponotif = SimpleIoc.Default.GetInstance<INotificatiesRepository>();
        private ITypeRepository repoType = SimpleIoc.Default.GetInstance<ITypeRepository>();


        public void DeleteNotificatieM()
        {
            reponotif.DeleteNotificatie(IngesteldeNotificaties);
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 12 };
            Messenger.Default.Send<GoToPageMessage>(message);

        }

        public async void GetTypes()
        {
            try
            {
                //IngesteldeNotificaties = await repoNotification.GetNotificaties();
                NotificatieType = await repoType.GetType(IngesteldeNotificaties.TypeID);
            }
            catch (Exception e) {

            }
        }

    }
}
