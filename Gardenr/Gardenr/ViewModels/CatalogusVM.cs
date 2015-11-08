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

namespace Gardenr.ViewModels
{
    class CatalogusVM : ObservableObject
    {
        public CatalogusVM()
        {
           
            GoToDetail = new RelayCommand(Detail);
            GetPlanten();
        }
        private IPlantRepository repoPlant = SimpleIoc.Default.GetInstance<IPlantRepository>();

      
        private ObservableCollection<Plant> _plant;

        public ObservableCollection<Plant> Planten
        {
            get { return _plant; }
            set { _plant = value; OnPropertyChanged("Planten"); }
        }

        public Plant SelectedPlant { get; set; }

        public RelayCommand GoToDetail
        {
            get; set;
        }
        public void Detail()
        {
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 2, SelectedPlant = SelectedPlant };
            Messenger.Default.Send<GoToPageMessage>(message);
        }

        public async void GetPlanten()
        { 
         //    repoPlant.AddPlant();
            Planten = await repoPlant.GetPlanten();
           
        }
    }
}
