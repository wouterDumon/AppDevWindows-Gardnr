using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.Models
{
    class Notificaties
    {
        public int ID { get; set; }
        public int PlantID { get; set; }       
        public int GebruikerID { get; set; }
        public string Omschrijving { get; set; }
        public DateTime Datum { get; set; }

    }
}
