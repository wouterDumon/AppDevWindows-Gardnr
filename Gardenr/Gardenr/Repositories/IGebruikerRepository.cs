using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Gardenr.Models;

namespace Gardenr.Repositories
{
    interface IGebruikerRepository
    {
        void AddGebruiker(Gebruiker data);
        void AdjustGebruiker(Gebruiker data);
        Task<ObservableCollection<Gebruiker>> GetGebruikers();
        Task<Gebruiker> GetGebruiker(string login);
    }
}