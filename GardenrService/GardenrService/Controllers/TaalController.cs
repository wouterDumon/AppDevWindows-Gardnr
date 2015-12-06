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
    public class TaalController : TableController<Taal>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            GardenrContext context = new GardenrContext();
            DomainManager = new EntityDomainManager<Taal>(context, Request, Services);
        }

        // GET tables/Taal
        public IQueryable<Taal> GetAllTaal()
        {
            return Query(); 
        }

        // GET tables/Taal/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Taal> GetTaal(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Taal/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Taal> PatchTaal(string id, Delta<Taal> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Taal
        public async Task<IHttpActionResult> PostTaal(Taal item)
        {
            Taal current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Taal/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTaal(string id)
        {
             return DeleteAsync(id);
        }

    }
}