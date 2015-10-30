using Gardenr.Models;
using System.Collections.Generic;

namespace Gardenr.Repositories
{
    internal interface IPlantRepository
    {
        List<Plant> GetPlanten();
       Plant GetPlantById(int id);
    }
}