using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Gardenr.Models;

namespace Gardenr.Repositories
{
    interface INieuwsRepository
    {
        void AddNewsItem(NieuwsItem nitem);
        void AdjustNewsItem(NieuwsItem nitem);
        void DeleteItem(NieuwsItem nitem);
        Task<NieuwsItem> GetNewsItem(string nitem);
        Task<ObservableCollection<NieuwsItem>> GetNewsItems();
    }
}