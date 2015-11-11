using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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

namespace Gardenr.ViewModels
{
    class ProfielVM : ViewModelBase
    {
        //menu navigatie huidig/favorieten/geschidenis zit er nog niet in
        public ProfielVM()
        {
            StartupGetItems();
            GoToTuinObject = new RelayCommand(TuinObjectDetail);
            AddTuinObject = new RelayCommand(AddTuinObjectM);
        }
        public ITuinRepository repoTuin = SimpleIoc.Default.GetInstance<ITuinRepository>();

        public List<TuinObject> TuinPlanten { get; set; }
        public TuinObject SelectedPlant { get; set; }
        public string SearchTerm { get; set; }

        public RelayCommand GoToTuinObject { get; set; }
        public void TuinObjectDetail()
        {//pag 7
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 7, SelectedTuinPlant = SelectedPlant };
            Messenger.Default.Send<GoToPageMessage>(message);
        }

        //zit in menu item
        public RelayCommand AddTuinObject { get; set; }
        public void AddTuinObjectM()
        {
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 7};
            Messenger.Default.Send<GoToPageMessage>(message);
        }


        //voor eventueel in het profiel in het tab favorieten bepaalde planten
        //te kunnen unfavoriten
        public RelayCommand NoMoreFav { get; set; }
        public void NoMoveFavM()
        {
            //aanduiden dat plant niet meer een favoriet is
        }

        public async void StartupGetItems()
        {
          //planten ophalen van de user
        }
    }

}
