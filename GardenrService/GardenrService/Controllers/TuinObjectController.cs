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
    public class TuinObjectController : TableController<TuinObject>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            GardenrContext context = new GardenrContext();
            DomainManager = new EntityDomainManager<TuinObject>(context, Request, Services);
        }

        // GET tables/TuinObject
        public IQueryable<TuinObject> GetAllTuinObject()
        {
            return Query(); 
        }

        // GET tables/TuinObject/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<TuinObject> GetTuinObject(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TuinObject/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<TuinObject> PatchTuinObject(string id, Delta<TuinObject> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/TuinObject
        public async Task<IHttpActionResult> PostTuinObject(TuinObject item)
        {
            TuinObject current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TuinObject/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTuinObject(string id)
        {
             return DeleteAsync(id);
        }

    }
}