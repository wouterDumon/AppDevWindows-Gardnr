using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Gardenr.Models;

namespace Gardenr.Repositories
{
    interface IAlarmRepository
    {
        Task AddNewsItem(Alarm nitem);
        void AdjustNewsItem(Alarm nitem);
        void DeleteItem(Alarm nitem);
        Task<Alarm> GetAlarmBID(string nitem);
        Task<ObservableCollection<Alarm>> GetAlarmItems();
    }
}