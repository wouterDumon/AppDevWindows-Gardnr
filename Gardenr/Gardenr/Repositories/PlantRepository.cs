using Gardenr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.Repositories
{
    class PlantRepository : IPlantRepository
    {
        public List<Plant> GetPlanten()
        {
            List<Plant> planten = new List<Plant>();

            return planten;
        }
        public Plant GetPlantById(int id)
        {
            Plant temp = new Plant();

            return temp;
        }

       
    }
}
