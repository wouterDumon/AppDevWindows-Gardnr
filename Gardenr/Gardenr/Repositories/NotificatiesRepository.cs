using Gardenr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.Repositories
{
    class NotificatiesRepository : INotificatiesRepository
    {
        public List<Notificatie> GetNotificaties()
        {
            List<Notificatie> notific = new List<Notificatie>();

            return notific;
        }
        public Notificatie GetNotificatieById(int id)
        {
            Notificatie not = new Notificatie();

            return not;
        }
        public void SaveNotificatie(Notificatie not)
        {

        }
        public void DeleteNotificatie(int id)
        {

        }
        public void AddNotification(Notificatie not)
        {

        }
    }

}
