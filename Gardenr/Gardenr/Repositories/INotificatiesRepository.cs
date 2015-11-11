using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Gardenr.Models;

namespace Gardenr.Repositories
{
    interface INotificatiesRepository
    {
        void AddNotificatie(Notificatie nitem);
        void AdjustNotificatie(Notificatie nitem);
        void DeleteNotificatie(Notificatie nitem);
        Task<Notificatie> GetNotificatie(string nitem);
        Task<ObservableCollection<Notificatie>> GetNotificaties();
    }
}