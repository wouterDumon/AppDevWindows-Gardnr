using System.Collections.Generic;
using Gardenr.Models;

namespace Gardenr.Repositories
{
    interface INieuwsRepository
    {
        List<NieuwsItem> GetNieuwsItems();
    }
}