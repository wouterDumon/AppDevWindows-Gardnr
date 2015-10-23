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
        public DateTime Oogstbegin { get; set; }

        

    }

    

}
