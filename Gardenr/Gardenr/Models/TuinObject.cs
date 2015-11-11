using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.Models
{
    public class TuinObject
    {
        public string ID { get; set; }
        public Plant Planten { get; set; }
        public Gebruiker gebruiker { get; set; }
        public bool favoriet {get; set; }
        public int Aantal { get; set; }
        public string LaatstWater { get; set; }
        public string extra { get; set; }
        public List<Notificatie> NotificationID { get; set; }
    }
}
