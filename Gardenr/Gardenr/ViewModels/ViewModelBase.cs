using Gardenr.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Gardenr.ViewModels
{
   class ViewModelBase : BindableBase
    {
        private static ObservableCollection<MenuItem> menu = new ObservableCollection<MenuItem>();

        public ViewModelBase()
        { }

        public ObservableCollection<MenuItem> Menu
        {
            get { return menu; }
        }
    }
}
