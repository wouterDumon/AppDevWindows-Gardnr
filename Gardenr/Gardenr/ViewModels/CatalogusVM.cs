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


        private string _zoek;
        public string Zoek {
            get { return _zoek; }
            set
            {
                _zoek = value; OnPropertyChanged("Zoek"); filter();
            }
            }

        private void filter() {

            /*List<Plant> t = Planten;
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                var item = listView1.Items[i];
                if (item.Text.ToLower().Contains(txt_Search.Text.ToLower()))
                {
                    item.BackColor = SystemColors.Highlight;
                    item.ForeColor = SystemColors.HighlightText;
                }
                else
                {
                    listView1.Items.Remove(item);
                }*/
            }


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
        
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 2, SelectedPlant = this.SelectedPlant };
            Messenger.Default.Send<GoToPageMessage>(message);
        }

        public async void GetPlanten()
        {
            //  repoPlant.AddPlant();
          
            Planten = await repoPlant.GetPlanten();
           
         
        }
    }
}
