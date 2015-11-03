using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WINAPI.Models
{
    public class Gebruiker
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public Instellingen InstellingenID { get; set; }
  
        public string Facebook { get; set; }

        public string Active { get; set; }
    }
}