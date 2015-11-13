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
    class HomeVM
    {
        public HomeVM()
        {
            StartUpGetItems();

        }

        private INotificatiesRepository repoNot = SimpleIoc.Default.GetInstance<INotificatiesRepository>();

        public ObservableCollection<Notificatie> Notificaties { get; set; }

        public Notificatie SelectedNotificatie { get; set; }

        //misschiencommands voor naar notificatie detail te gaan
        private INieuwsRepository repoNieuws = SimpleIoc.Default.GetInstance<INieuwsRepository>();
        public ObservableCollection<NieuwsItem> NieuwsItems { get; set; }
        public NieuwsItem SelectedNieuwsItem { get; set; }

        public async void StartUpGetItems()
        {
     //       Notificaties = await repoNot.GetNotificaties();
       //     NieuwsItems = await repoNieuws.GetNewsItems();
        }
    }
}
