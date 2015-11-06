using Gardenr.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gardenr.Repositories
{
    internal interface IPlantRepository
    {
       Task<List<Plant>> GetPlanten();
       Task<Plant> GetPlantById(int id);
       void AddPlant();
    }
}