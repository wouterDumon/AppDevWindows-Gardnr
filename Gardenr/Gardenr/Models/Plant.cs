using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.Models
{
    public class Plant
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Description { get; set; }
        public string FotoUrl { get; set; }
        public DateTime ZaaiBegin { get; set; }
        public DateTime ZaaiEind { get; set;}
        public DateTime OogstBegin { get; set; }
        public DateTime OogstEind { get; set; }
        public DateTime PlantBegin { get; set; }
        public DateTime PlantEinde { get; set; }
        public int ZaaiDiepte { get; set; }
        public int Afstand { get; set; }
        public int AfstandRij { get; set; }
        public int WaterGeven { get; set; }
        public int DagenOogst { get; set; }
        public int DagenVerplant { get; set; }
        public bool Binnen { get; set; }
        public bool Buiten { get; set; }
        

    }

    

}
