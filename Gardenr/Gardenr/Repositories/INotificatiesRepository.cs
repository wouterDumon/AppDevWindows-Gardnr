using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Gardenr.Models;

namespace Gardenr.Repositories
{
    interface INotificatiesRepository
    {
        Task AddNotificatie(Notificaties nitem);
        void AdjustNotificatie(Notificaties nitem);
        void DeleteNotificatie(Notificaties nitem);
        Task<Notificaties> GetNotificatie(string nitem);
        Task<ObservableCollection<Notificaties>> GetNotificaties();
        Task<ObservableCollection<SpecNotificaties>> GetpecNotificaties();
    }
}