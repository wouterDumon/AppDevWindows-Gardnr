using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WINAPI.Models
{
    public class Tuin
    {
        public Plant Cat_ID { get; set; }
        public Gebruiker Gebruiker_ID { get; set; }
        public int Favoriet { get; set; }
        public int Aantal { get; set; }
        public string GeplantOP { get; set; }
        public string LaatstWater { get; set; }
        public int ID { get; set; }
        public string Extra { get; set; }


    }
}
