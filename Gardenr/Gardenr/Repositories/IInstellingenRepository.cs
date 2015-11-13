using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Gardenr.Models;

namespace Gardenr.Repositories
{
    interface IInstellingenRepository
    {
        Task AddInst(Instellingen nitem);
        void AdjustInst(Instellingen nitem);
        void DeleteInst(Instellingen nitem);
        Task<Instellingen> GetInst(string nitem);
        Task<ObservableCollection<Instellingen>> GetInsts();
    }
}