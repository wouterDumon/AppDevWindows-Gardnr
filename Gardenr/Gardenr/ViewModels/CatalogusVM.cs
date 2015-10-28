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
    class CatalogusVM : ViewModelBase
    {
        public CatalogusVM()
        {
            GoToDetail = new RelayCommand(Detail);
        }
        private IPlantRepository repoPlant = SimpleIoc.Default.GetInstance<IPlantRepository>();

        public List<Plant> Planten { get; set; }

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

    }
}
