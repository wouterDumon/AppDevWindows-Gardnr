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
    public class InstellingenController : TableController<Instellingen>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            GardenrContext context = new GardenrContext();
            DomainManager = new EntityDomainManager<Instellingen>(context, Request, Services);
        }

        // GET tables/Instellingen
        public IQueryable<Instellingen> GetAllInstellingen()
        {
            return Query(); 
        }

        // GET tables/Instellingen/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Instellingen> GetInstellingen(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Instellingen/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Instellingen> PatchInstellingen(string id, Delta<Instellingen> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Instellingen
        public async Task<IHttpActionResult> PostInstellingen(Instellingen item)
        {
            Instellingen current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Instellingen/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteInstellingen(string id)
        {
             return DeleteAsync(id);
        }

    }
}