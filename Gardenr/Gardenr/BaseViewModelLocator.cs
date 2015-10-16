using GalaSoft.MvvmLight.Ioc;
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
            SimpleIoc.Default.Register<MainePageVM>();
           /* SimpleIoc.Default.Register<Page2VM>();
            SimpleIoc.Default.Register<ICountryRepository, CountryRepository>();
            SimpleIoc.Default.Register<ICityRepository1, CityRepository>();
            SimpleIoc.Default.Register<IWeerRepository, WeerRepository>();*/
        }
        public MainePageVM MainPage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainePageVM>();

            }


        }/*


        public Page2VM Page2
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Page2VM>();

            }


        }*/


    }
}
