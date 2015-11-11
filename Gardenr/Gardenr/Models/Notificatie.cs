using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.Models
{
    public class Notificatie
    {
        public string ID { get; set; }
        public TypeC TypeId { get; set; }
        public string Omschrijving { get; set; }
        public Alarm Alarm { get; set; }
        public Gebruiker GebruikerID { get; set; }
        public Plant Plant { get; set; }

    }
}
