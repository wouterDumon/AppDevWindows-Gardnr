using Gardenr.Models;

namespace Gardenr.Repositories
{
    interface IGebruikerRepository
    {
        Gebruiker GetGebruikerGegevensByFacebook(string facebooklogin);
    }
}