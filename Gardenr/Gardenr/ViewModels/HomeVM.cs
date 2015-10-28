using GalaSoft.MvvmLight.Ioc;
using Gardenr.Models;
using Gardenr.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.ViewModels
{
    class HomeVM
    {
        public HomeVM()
        {
            Notificaties= repoNot.GetNotificaties();
            NieuwsItems = repoNieuws.GetNieuwsItems();
        }

        private INotificatiesRepository repoNot = SimpleIoc.Default.GetInstance<INotificatiesRepository>();

        public List<Notificaties> Notificaties { get; set; }

        public Notificaties SelectedNotificatie { get; set; }

        //misschiencommands voor naar notificatie detail te gaan
        private INieuwsRepository repoNieuws = SimpleIoc.Default.GetInstance<INieuwsRepository>();
        public List<NieuwsItem> NieuwsItems { get; set; }
        public NieuwsItem SelectedNieuwsItem { get; set; }
    }
}
