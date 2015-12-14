using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Gardenr.Mesages;
using Gardenr.Models;
using Gardenr.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherNet;
using WeatherNet.Clients;
using Windows.Devices.Geolocation;

namespace Gardenr.ViewModels
{
    class HomeVM : ViewModelBase
    {
        public HomeVM()
        {
            //WeatherNet.Clients.CurrentWeather mijnweer= new WeatherNet.Clients.CurrentWeather();

            //  mijnweer.GetByCityNameAsync("Rekkem", "Belgium");
            NaamFoto = "radijzen";
            DagFoto = "http://student.howest.be/lucas.balcaen/androidappfotos/radijzen.png";
               StartUpGetItems();
            naam = App.Gebruiker.Voornaam + " " + App.Gebruiker.Naam;
            VieuwNotification = new RelayCommand(VieuwNotificationM);
            VieuwNieuwsItem = new RelayCommand(VieuwNieuwsItemM);
            AddNotificatie = new RelayCommand(AddNotificatieM);
        }

        private string naam { get; set; }
        private string _fotourl;
        private string _weertext;
        private string _weerstatus;
        private string _weerlocatie;

        public string Weerlocatie
        {
            get { return _weerlocatie; }
            set { _weerlocatie = value; OnPropertyChanged("Weerlocatie"); }
        }        
        public string Weerstatus
        {
            get { return _weerstatus; }
            set { _weerstatus = value; OnPropertyChanged("Weerstatus"); }
        }
        public string Weertext
        {
            get { return _weertext; }
            set { _weertext = value; OnPropertyChanged("Weertext"); }
        }
        public string Fotourl
        {
            get { return _fotourl; }
            set { _fotourl = value; OnPropertyChanged("Fotourl"); }
        }

        private String _dagfoto;

        public String DagFoto
        {
            get { return _dagfoto; }
            set { _dagfoto = value; OnPropertyChanged("DagFoto"); }
        }
        private String _naamFoto;

        public String NaamFoto
        {
            get { return _naamFoto; }
            set { _naamFoto = value; OnPropertyChanged("NaamFoto"); }
        }


        public async void FILLUPWEER(string lat, string lon) {
            double la = Double.Parse(lat);
            double lo = Double.Parse(lon);
            var weerresult = await CurrentWeather.GetByCoordinatesAsync(la, lo, "nl", "metric");
            //http://openweathermap.org/img/w/10d.png
            //site om icoon op te halen
            Fotourl = "http://openweathermap.org/img/w/" + weerresult.Item.Icon+".png";
            Weertext = "" + weerresult.Item.Temp + "°C";
            Weerstatus = "" + weerresult.Item.Description;
            Weerlocatie = "" + weerresult.Item.City + "," + weerresult.Item.Country;
        }

        private INotificatiesRepository repoNotification = SimpleIoc.Default.GetInstance<INotificatiesRepository>();

        private ObservableCollection<Notificaties> _notificaties;
        public ObservableCollection<Notificaties> Notificaties
        {
            get
            {
                return _notificaties;
            }
            set
            {
                _notificaties = value; OnPropertyChanged("Notificaties");
            }
        }

        private Notificaties _selectedNotificatie;
        public Notificaties SelectedNotificatie
        {
            get { return _selectedNotificatie; }
            set { _selectedNotificatie = value; OnPropertyChanged("SelectedNotificatie"); }
        }

        //misschiencommands voor naar notificatie detail te gaan
        private INieuwsRepository repoNieuws = SimpleIoc.Default.GetInstance<INieuwsRepository>();

        private ObservableCollection<NieuwsItem> _nieuwsItems;
        public ObservableCollection<NieuwsItem> NieuwsItems
        {
            get { return _nieuwsItems; }
            set { _nieuwsItems = value; OnPropertyChanged("NieuwsItems"); }
        }
        private NieuwsItem _selectedNieuwsItem;
        public NieuwsItem SelectedNieuwsItem
        {
            get { return _selectedNieuwsItem; }
            set { _selectedNieuwsItem = value; OnPropertyChanged("SelectedNieuwsItem"); }
        }

        public async void StartUpGetItems()
        {
            //nog doen zodanig dat de notificaties enkel van de ingelogd gebruiker ingegeven worden



            ClientSettings.SetApiKey("0dfd8f010d58f1038ed8c4392529f3e5");

            Notificaties = await repoNotification.GetNotificaties();
            NieuwsItems = await repoNieuws.GetNewsItems();
   
          //  string a =ClientSettings.ApiKey;
          //  string b = ClientSettings.ApiUrl;
           // var result = CurrentWeather.GetByCityNameAsync("Menen", "BE", "nl", "metric");
           
           
        }
      


        public RelayCommand VieuwNotification { get; set; }
        public void VieuwNotificationM()
        {
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 5, SelectedNotificatie = SelectedNotificatie };
            Messenger.Default.Send<GoToPageMessage>(message);
        }
        public RelayCommand VieuwNieuwsItem { get; set; }
        public void VieuwNieuwsItemM()
        {

        }


        public RelayCommand AddNotificatie { get; set; }
        public void AddNotificatieM()
        {
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 6 };
            Messenger.Default.Send<GoToPageMessage>(message);
        }
    }
}
