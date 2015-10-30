using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.Models
{
    class Gebruiker
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public Instellingen Instellingen { get; set; }       
        public string Facebook { get; set; }
        public bool Active { get; set; }
    }
}
