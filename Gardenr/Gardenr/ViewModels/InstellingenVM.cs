using GalaSoft.MvvmLight.Command;
using Gardenr.Models;
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
        }


        public Instellingen UserSettings { set; get; }

        public RelayCommand SaveSettings { get; set; }
        public void Settings()
        {

        }
    }
}
