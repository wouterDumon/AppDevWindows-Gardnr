using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.Models
{
    class DrawerInstellingen
    {
        private string _naam;

        public string Naam
        {
            get { return _naam; }
            set { _naam = value; }
        }
        private string _fotourl;

        public string Fotourl
        {
            get { return _fotourl; }
            set { _fotourl = value; }
        }

    }
}
