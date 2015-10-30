using System.Collections.Generic;
using Gardenr.Models;

namespace Gardenr.Repositories
{
    interface ITaalRepository
    {
        Taal GetTaalById(int id);
        List<Taal> GetTalen();
    }
}