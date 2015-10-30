using System.Collections.Generic;
using Gardenr.Models;

namespace Gardenr.Repositories
{
    interface INotificatiesRepository
    {
        List<Notificaties> GetNotificaties();
        Notificaties GetNotificatieById(int id);
        void SaveNotificatie(Notificaties not);
        void DeleteNotificatie(int id);
        void AddNotification(Notificaties not);
    }
}