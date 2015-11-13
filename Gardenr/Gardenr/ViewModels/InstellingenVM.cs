using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
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
    class InstellingenVM : ViewModelBase
    {
        public InstellingenVM()
        {
            SaveSettings = new RelayCommand(Settings);
            //UserSettings = repoInst.GetInstellingenById(1);//temp 

            GetInstellingen();

        }

        private async void GetInstellingen()
        {
          UserSettings =   await repoInst.GetInst(App.Gebruiker.InstellingenID);
            
            Talen = await repotaal.GetTalen();
            foreach (Taal t in Talen) {
                if (UserSettings.TaalID == t.ID) {
                    Taale = t;
                }
            }
         

        }



        private IInstellingenRepository repoInst = SimpleIoc.Default.GetInstance<IInstellingenRepository>();
        private ITaalRepository repotaal = SimpleIoc.Default.GetInstance<ITaalRepository>();
        private ObservableCollection<Taal> _talen;

        public ObservableCollection<Taal> Talen
        {
            get { return _talen; }
            set { _talen = value; OnPropertyChanged("Talen"); }
        }


        private Instellingen _usersettings;

        public Instellingen UserSettings
        {
            get { return _usersettings; }
            set { _usersettings = value; OnPropertyChanged("UserSettings"); }
        }


        private Taal _taal;

        public Taal Taale
        {
            get { return _taal; }
            set { _taal = value; OnPropertyChanged("Taale"); }
        }


        public RelayCommand SaveSettings { get; set; }
        public void Settings()
        {
            if (Taale != null)
            {
                if (App.Gebruiker.InstellingenID == "1")
                {
                    //STANDAARD INSTELLING MAAK NIEUWE
                    Instellingen Nieuw = new Instellingen();
                    Nieuw = UserSettings;
                    Nieuw.TaalID = Taale.ID;
                    //repoInst.AddInst(Nieuw);

                }
                else
                {
                    Instellingen Nieuw = new Instellingen();
                    Nieuw = UserSettings;
                    Nieuw.TaalID = Taale.ID;
                    //repoInst.AdjustInst(Nieuw);

                }
            }
        }

        
    }
}
