using GalaSoft.MvvmLight.Command;
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
    class InstellingenVM
    {
        public InstellingenVM()
        {
            SaveSettings = new RelayCommand(Settings);
            UserSettings = repoInst.GetInstellingenById(1);//temp id
        }
        private IInstellingenRepository repoInst = SimpleIoc.Default.GetInstance<IInstellingenRepository>(); 

        public Instellingen UserSettings { set; get; }
        public Taal SelectedTaal { get; set; }


        public RelayCommand SaveSettings { get; set; }
        public void Settings()
        {

        }

        
    }
}
