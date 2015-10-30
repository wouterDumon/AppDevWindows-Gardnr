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
        public List<Notificaties> GetNotificaties()
        {
            List<Notificaties> notific = new List<Notificaties>();

            return notific;
        }
        public Notificaties GetNotificatieById(int id)
        {
            Notificaties not = new Notificaties();

            return not;
        }
        public void SaveNotificatie(Notificaties not)
        {

        }
        public void DeleteNotificatie(int id)
        {

        }
        public void AddNotification(Notificaties not)
        {

        }
    }

}
