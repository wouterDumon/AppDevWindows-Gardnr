using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gardenr.Models;

namespace Gardenr.Repositories
{
    class TuinRepository : ITuinRepository
    {
        public List<TuinObject> GetTuinObjectsById(int id)
        {
            List<TuinObject> objects = new List<TuinObject>();

            return objects;
        }
        public void AddTuinObject(TuinObject tobject)
        {

        }
        public void DeleteTuinObject(int id)
        {

        }
        public void Adjust(TuinObject tobject)
        {
        }
    }
}
