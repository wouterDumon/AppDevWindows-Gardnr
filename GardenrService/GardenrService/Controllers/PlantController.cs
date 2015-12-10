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
    public class PlantController : TableController<Plant>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            GardenrContext context = new GardenrContext();
            DomainManager = new EntityDomainManager<Plant>(context, Request, Services);
        }

        // GET tables/Plant
        public IQueryable<Plant> GetAllPlant()
        {
            return Query(); 
        }

        // GET tables/Plant/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Plant> GetPlant(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Plant/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Plant> PatchPlant(string id, Delta<Plant> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Plant
        public async Task<IHttpActionResult> PostPlant(Plant item)
        {
            Plant current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Plant/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeletePlant(string id)
        {
             return DeleteAsync(id);
        }

    }
}