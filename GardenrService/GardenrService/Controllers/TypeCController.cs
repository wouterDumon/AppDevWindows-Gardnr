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
    public class TypeCController : TableController<TypeC>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            GardenrContext context = new GardenrContext();
            DomainManager = new EntityDomainManager<TypeC>(context, Request, Services);
        }

        // GET tables/TypeC
        public IQueryable<TypeC> GetAllTypeC()
        {
            return Query(); 
        }

        // GET tables/TypeC/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<TypeC> GetTypeC(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TypeC/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<TypeC> PatchTypeC(string id, Delta<TypeC> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/TypeC
        public async Task<IHttpActionResult> PostTypeC(TypeC item)
        {
            TypeC current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TypeC/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTypeC(string id)
        {
             return DeleteAsync(id);
        }

    }
}