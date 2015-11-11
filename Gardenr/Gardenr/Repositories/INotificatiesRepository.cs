using System.Collections.Generic;
using Gardenr.Models;

namespace Gardenr.Repositories
{
    interface INotificatiesRepository
    {
        List<Notificatie> GetNotificaties();
        Notificatie GetNotificatieById(int id);
        void SaveNotificatie(Notificatie not);
        void DeleteNotificatie(int id);
        void AddNotification(Notificatie not);
    }
}