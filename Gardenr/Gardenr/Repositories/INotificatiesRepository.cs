using System.Collections.Generic;
using Gardenr.Models;

namespace Gardenr.Repositories
{
    interface INotificatiesRepository
    {
        List<Notificaties> GetNotificaties();
    }
}