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
        public List<TuinObject> Planten { get; set; }
    }
}
