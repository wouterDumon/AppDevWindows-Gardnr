using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Gardenr.Mesages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.ViewModels
{
    class MenuVM : ViewModelBase
    {
        public MenuVM()
        {
            //home
            HomeCommand = new RelayCommand(GoHome);

            //profiel
            ProfielCommand = new RelayCommand(GoProfiel);
            //catalogus
            CatalogusCommand = new RelayCommand(GoCatalogus);
            //constact
            ContactCommand = new RelayCommand(GoContact);
            //instellingen
            InstellingenCommand = new RelayCommand(GoInstellingen);
        }
        public RelayCommand HomeCommand
        { get; set; }
        public RelayCommand ProfielCommand
        { get; set; }
        public RelayCommand CatalogusCommand
        { get; set; }
        public RelayCommand ContactCommand
        { get; set; }
        public RelayCommand InstellingenCommand
        { get; set; }

        public void GoHome()
        {
            //11
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 11 };
            Messenger.Default.Send<GoToPageMessage>(message);
        }
        public void GoProfiel()
        {
            //10
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 10 };
            Messenger.Default.Send<GoToPageMessage>(message);
        }
        public void GoCatalogus()
        {
            //1
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 1 };
            Messenger.Default.Send<GoToPageMessage>(message);
        }
        public void GoContact()
        {
            //3
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 3 };
            Messenger.Default.Send<GoToPageMessage>(message);
        }
        public void GoInstellingen()
        {
            //5
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 5 };
            Messenger.Default.Send<GoToPageMessage>(message);
        } 

    }
}
