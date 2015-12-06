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

    public class NotificatiesController : TableController<Notificaties>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            GardenrContext context = new GardenrContext();
            DomainManager = new EntityDomainManager<Notificaties>(context, Request, Services);
        }

        // GET tables/Notificaties
        public IQueryable<Notificaties> GetAllNotificaties()
        {
            return Query(); 
        }

        // GET tables/Notificaties/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Notificaties> GetNotificaties(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Notificaties/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Notificaties> PatchNotificaties(string id, Delta<Notificaties> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Notificaties
        public async Task<IHttpActionResult> PostNotificaties(Notificaties item)
        {
            Notificaties current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Notificaties/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteNotificaties(string id)
        {
             return DeleteAsync(id);
        }

    }
}