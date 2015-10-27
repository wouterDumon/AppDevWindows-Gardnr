using GalaSoft.MvvmLight;
using Gardenr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace Gardenr.ViewModels
{
    class CatalogusPlantVM : ViewModelBase
    {
        protected void OnNavigatedTo(NavigationEventArgs e)
        {
            this.plant = e.Parameter as Plant;
        }

        public Plant plant { get; set; }
    }
}
