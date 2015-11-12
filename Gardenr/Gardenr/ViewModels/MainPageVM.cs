using Facebook;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Gardenr.Mesages;
using Gardenr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store;
using Windows.Security.Authentication.Web;

namespace Gardenr.ViewModels
{
    //erven niet vergeten is verplicht!
    class MainPageVM : ViewModelBase
    {
      
        public MainPageVM()
        {
            
            Testing = new RelayCommand(TestingM);
        }
 
 
        public RelayCommand Testing { get; set; }
        public void TestingM()
        {
            
                  
                     GoToPageMessage message = new GoToPageMessage() { PageNumber = 1 };
            Messenger.Default.Send<GoToPageMessage>(message);
             
              
           
       /*
            GoToPageMessage message = new GoToPageMessage() { PageNumber = 1 };
            Messenger.Default.Send<GoToPageMessage>(message);*/
        }

    }
}
