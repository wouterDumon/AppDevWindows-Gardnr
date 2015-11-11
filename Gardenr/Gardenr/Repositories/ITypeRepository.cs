using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Gardenr.Models;

namespace Gardenr.Repositories
{
    interface ITypeRepository
    {
        void AddType(TypeC nitem);
        void AdjustType(TypeC nitem);
        void DeleteType(TypeC nitem);
        Task<TypeC> GetType(string nitem);
        Task<ObservableCollection<TypeC>> GetTypes();
    }
}