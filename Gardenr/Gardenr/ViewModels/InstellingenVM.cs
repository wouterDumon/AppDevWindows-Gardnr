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
        private int iii = 0;
        public InstellingenVM()
        {
            iii = 0;
            SaveSettings = new RelayCommand(Settings);
            //UserSettings = repoInst.GetInstellingenById(1);//temp 
           //repotaal.AddTaal();
            //Instellingen a = new Instellingen();
          // a.ID = "1";
           // a.PushNotificaties = true;
          //a.Cortana = true;
          // a.TaalID = "332e6b7e-a6da-4ed7-a819-b18793ad91b8";
           //repoInst.AddInst(a);
         GetInstellingen();

        }

        private async void GetInstellingen()
        {
          UserSettings =   await repoInst.GetInst(App.Gebruiker.InstellingenID);
            
            if (UserSettings.PushNotificaties == true)
            {
                Aan = true;
                Uit = false;
            }
            else {
                Aan = false;
                Uit = true;
            }         

        }



        private IInstellingenRepository repoInst = SimpleIoc.Default.GetInstance<IInstellingenRepository>();
        private IGebruikerRepository repogebruiker = SimpleIoc.Default.GetInstance<IGebruikerRepository>();
        private ITaalRepository repotaal = SimpleIoc.Default.GetInstance<ITaalRepository>();
        private Boolean _aan;

        public Boolean Aan
        {
            get { return _aan; }
            set { _aan = value; OnPropertyChanged("Aan"); }
        }
        private Boolean _uit;

        public Boolean Uit
        {
            get { return _uit; }
            set { _uit = value; OnPropertyChanged("Uit"); }
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
        public async void Settings()
        {
            iii++;
            if (iii > 1) {
               
                    if (App.Gebruiker.InstellingenID == "1")
                    {
                        //STANDAARD INSTELLING MAAK NIEUWE
                        Instellingen Nieuw = new Instellingen();
                        
                        Nieuw.Cortana = true;
                        if (Aan == true)
                        {
                            Nieuw.PushNotificaties = true;
                        }
                        else {
                            Nieuw.PushNotificaties = false;
                        }

                       
                        Nieuw.TaalID = "1";
                    await repoInst.AddInst(Nieuw);
                        string nieuwid = Nieuw.ID;
                       Gebruiker n = App.Gebruiker;
                        n.InstellingenID = nieuwid;
                        repogebruiker.AdjustGebruiker(n);

                    }
                    else
                    {
                        Instellingen Nieuw = new Instellingen();
                        Nieuw = UserSettings;
                        if (Aan == true)
                        {
                            Nieuw.PushNotificaties = true;
                        }
                        else
                        {
                            Nieuw.PushNotificaties = false;
                        }
                        repoInst.AdjustInst(Nieuw);

                    }
                }
            
        }

      

    }
}
