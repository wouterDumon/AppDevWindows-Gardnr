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
        public string Omschrijving { get; set; }
        public string FotoUrl { get; set; }
        public string ZaaiBegin { get; set; }
        public string ZaaiEinde { get; set; }
        public string PlantBegin { get; set; }
        public string PlantEinde { get; set; }
        public string OogstBegin { get; set; }
        public string OogstEinde { get; set; }
        public string ZaaiDiepte { get; set; }
        public string AfstandTussen { get; set; }
        public string AfstandRij { get; set; }
        public string WaterGeven { get; set; }
        public string DagenOogst { get; set; }
        public string DagenVerplanten { get; set; }
        public int Buiten { get; set; }
        public int Binnen { get; set; }


    }

    

}
