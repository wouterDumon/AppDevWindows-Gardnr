using System.Collections.Generic;
using Gardenr.Models;

namespace Gardenr.Repositories
{
    interface ITuinRepository
    {
        void AddTuinObject(TuinObject tobject);
        void Adjust(TuinObject tobject);
        void DeleteTuinObject(int id);
        List<TuinObject> GetTuinObjectsById(int id);
    }
}