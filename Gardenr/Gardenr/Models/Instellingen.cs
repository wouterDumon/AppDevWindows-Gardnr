using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.Models
{
    public class Instellingen
    {
        public int ID { get; set; }
        public Taal Taal { get; set; }
        public bool Cortana { get; set; }
        public bool PushNotificaties { get; set; }
    }
}
