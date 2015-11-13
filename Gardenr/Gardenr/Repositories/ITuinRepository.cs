using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Gardenr.Models;

namespace Gardenr.Repositories
{
    interface ITuinRepository
    {
        void AddTO(TuinObject nitem);
        void AdjustTO(TuinObject nitem);
        void DeleteTO(TuinObject nitem);
        Task<ObservableCollection<Tuin>> GetTOs(string gebruikerid);
        Task<Tuin> GetTO(string nitem);
    }
}