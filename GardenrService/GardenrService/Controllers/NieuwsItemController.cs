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
    public class NieuwsItemController : TableController<NieuwsItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            GardenrContext context = new GardenrContext();
            DomainManager = new EntityDomainManager<NieuwsItem>(context, Request, Services);
        }

        // GET tables/NieuwsItem
        public IQueryable<NieuwsItem> GetAllNieuwsItem()
        {
            return Query(); 
        }

        // GET tables/NieuwsItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<NieuwsItem> GetNieuwsItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/NieuwsItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<NieuwsItem> PatchNieuwsItem(string id, Delta<NieuwsItem> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/NieuwsItem
        public async Task<IHttpActionResult> PostNieuwsItem(NieuwsItem item)
        {
            NieuwsItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/NieuwsItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteNieuwsItem(string id)
        {
             return DeleteAsync(id);
        }

    }
}