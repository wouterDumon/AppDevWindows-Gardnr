using Gardenr.Models;

namespace Gardenr.Repositories
{
    interface IInstellingenRepository
    {
        Instellingen GetInstellingenById(int id);
    }
}