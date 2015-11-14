using Gardenr.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Gardenr.Repositories
{
    internal interface IPlantRepository
    {
       Task<ObservableCollection<Plant>> GetPlanten();
       Task<Plant> GetPlantById(string id);

       void AddPlant(Plant nieuweplant);
    }
}