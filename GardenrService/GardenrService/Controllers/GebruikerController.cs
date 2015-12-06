using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using GardenrService.DataObjects;
using GardenrService.Models;



namespace GardenrService.Controllers
{

    public class GebruikerController : TableController<Gebruiker>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            GardenrContext context = new GardenrContext();
            DomainManager = new EntityDomainManager<Gebruiker>(context, Request, Services);
        }

        // GET tables/Gebruiker
        public IQueryable<Gebruiker> GetAllGebruiker()
        {
            return Query(); 
        }

        // GET tables/Gebruiker/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Gebruiker> GetGebruiker(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Gebruiker/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Gebruiker> PatchGebruiker(string id, Delta<Gebruiker> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Gebruiker
        public async Task<IHttpActionResult> PostGebruiker(Gebruiker item)
        {
            Gebruiker current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Gebruiker/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteGebruiker(string id)
        {
             return DeleteAsync(id);
        }

    }
}