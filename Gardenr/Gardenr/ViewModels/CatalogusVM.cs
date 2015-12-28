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
    class CatalogusVM : ViewModelBase
    {
        public CatalogusVM()
        {
           
            GoToDetail = new RelayCommand(Detail);
            GetPlanten();
        }
        private IPlantRepository repoPlant = SimpleIoc.Default.GetInstance<IPlantRepository>();

        private String _width;

        public String width
        {
            get { return _width; }
            set { _width = value; OnPropertyChanged("width"); }
        }


        private string _zoek;
        public string Zoek {
            get { return _zoek; }
            set
            {
                _zoek = value; OnPropertyChanged("Zoek"); filter();
            }
            }

        private void filter() {
           // ToonPlanten.Clear();
            var filter = from Plant in Planten let item= Plant.Naam.ToLower()
                         where item.Contains(Zoek.ToLower()) select Plant;
            ToonPlanten.Clear();
            foreach (Plant p in  filter) {
                ToonPlanten.Add(p);

            }
            
        }

        private ObservableCollection<Plant> _toonplant;

        public ObservableCollection<Plant> ToonPlanten
        {
            get { return _toonplant; }
            set { _toonplant = value; OnPropertyChanged("ToonPlanten"); }
        }
        private ObservableCollection<Plant> _plant;

        public ObservableCollection<Plant> Planten
        {
            get { return _plant; }
            set { _plant = value;  }
        }

        public Plant SelectedPlant { get; set; }

        public RelayCommand GoToDetail
        {
            get; set;
        }
        public void Detail()
        {
            if (SelectedPlant == null) return;
        
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 2, SelectedPlant = this.SelectedPlant };
            Messenger.Default.Send<GoToPageMessage>(message);
        }

        public async void GetPlanten()
        {
            //  repoPlant.AddPlant();
          
            Planten = await repoPlant.GetPlanten();
            ToonPlanten = new ObservableCollection<Plant>();
            foreach (Plant p in Planten) {
                ToonPlanten.Add(p);
            }
       
         
        }
    }
}
