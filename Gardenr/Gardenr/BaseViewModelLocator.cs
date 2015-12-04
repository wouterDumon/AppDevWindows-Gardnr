using GalaSoft.MvvmLight.Ioc;
using Gardenr.Repositories;
using Gardenr.ViewModels;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr
{
    class BaseViewModelLocator
    {
        public BaseViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainPageVM>();
            SimpleIoc.Default.Register<CatalogusVM>();
            SimpleIoc.Default.Register<CatalogusPlantVM>();
            SimpleIoc.Default.Register<ContactVM>();
            SimpleIoc.Default.Register<HomeVM>();
            SimpleIoc.Default.Register<InstellingenVM>();
            SimpleIoc.Default.Register<NotificatiesBewerkenVM>();
            SimpleIoc.Default.Register<NotificatiesVM>();
            SimpleIoc.Default.Register<PlantBewerkenVM>();
            SimpleIoc.Default.Register<ProfielVM>();

            //  SimpleIoc.Default.Register<ICountryRepositorie, CountryRepositorie>();
            SimpleIoc.Default.Register<IPlantRepository, PlantRepository>();
            SimpleIoc.Default.Register<IGebruikerRepository,GebruikerRepository>();
            SimpleIoc.Default.Register<IInstellingenRepository,InstellingenRepository>();
            SimpleIoc.Default.Register<INieuwsRepository,NieuwsRepository>();
            SimpleIoc.Default.Register<INotificatiesRepository,NotificatiesRepository>();
            SimpleIoc.Default.Register<ITaalRepository,TaalRepository>();
            SimpleIoc.Default.Register<ITuinRepository,TuinRepository>();
            SimpleIoc.Default.Register<ITypeRepository, TypeRepository>();
        }


        public MainPageVM MainPage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainPageVM>();
            }
        }

        public CatalogusVM Catalogus
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CatalogusVM>();
            }
        }

        public CatalogusPlantVM CatalogusPlant
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CatalogusPlantVM>();
            }
        }
        public ContactVM Contact
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ContactVM>();
            }
        }
        public HomeVM Home
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeVM>();
            }
        }
        public InstellingenVM Instellingen
        {
            get
            {
                return ServiceLocator.Current.GetInstance<InstellingenVM>();
            }
        }
        public NotificatiesBewerkenVM NotificatiesBewerken
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NotificatiesBewerkenVM>();
            }
        }
        public NotificatiesVM Notificaties
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NotificatiesVM>();
            }
        }
        public PlantBewerkenVM PlantBewerken
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PlantBewerkenVM>();
            }
        }
        public ProfielVM Profiel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProfielVM>();
            }
        }
    }
}
