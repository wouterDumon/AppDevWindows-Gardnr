using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.Models
{
    class Plant
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Description { get; set; }
        public string FotoUrl { get; set; }
        public DateTime ZaaiBegin { get; set; }
        public DateTime ZaaiEind { get; set;}
        public DateTime OogstBegin { get; set; }
        public DateTime Oogstbegin { get; set; }

        public List<Plant> GetPlanten()
        {
            List<Plant> temp = new List<Plant>();

            return temp;
        }
        public Plant GetPlantByID(int id)
        {
            Plant temp = new Plant();

            return temp;
        }

    }

    

}
