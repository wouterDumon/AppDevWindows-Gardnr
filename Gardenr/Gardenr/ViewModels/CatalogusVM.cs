using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
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
        private IPlantRepository repoPlant = SimpleIoc.Default.GetInstance<IPlantRepository>();

        public List<Plant> Planten { get; set; }

        public Plant SelectedPlant { get; set; }
    }
}
