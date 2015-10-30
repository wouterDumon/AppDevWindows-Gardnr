using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.Models
{
    public class Notificaties
    {
        public int ID { get; set; }
        public TypeC TypeId { get; set; }
        public string Omschrijving { get; set; }
        public DateTime AlarmTijd { get; set; }
        public Alarm Alarm { get; set; }
        public int GebruikerID { get; set; }
        public Plant Plant { get; set; }

    }
}
