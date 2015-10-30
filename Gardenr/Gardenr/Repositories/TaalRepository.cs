using Gardenr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.Repositories
{
    class TaalRepository : ITaalRepository
    {
        public List<Taal> GetTalen()
        {
            List<Taal> tal = new List<Taal>();
            return tal;
        }
        public Taal GetTaalById(int id)
        {
            Taal tal = new Taal();

            return tal;
        }
    }
}
