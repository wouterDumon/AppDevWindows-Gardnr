using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.Models
{
    public class Gebruiker
    {
        public string ID { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string InstellingenID { get; set; }       
        public string Facebook { get; set; }
        public bool Active { get; set; }
    }
}
