using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.Models
{
    class Tuin
    {
       public int ID { get; set; }
       public List<Plant> Planten{ get; set; }
       public List<Plant> FavorietePlanten { get; set; }
       public List<Notificaties> Notificatie { get; set; }
       public int GebruikerID { get; set; }

       

    }
}
