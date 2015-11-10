using Gardenr.Models;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Gardenr.Repositories
{
    class DataRepository
    {
       
      public IEnumerable GetItems(Type deklasse)
      {
            var name = deklasse.Name;
                        
            return pat;
      }
     
    private static ObservableCollection<T> CreateObservable(IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }





    
    }
}
