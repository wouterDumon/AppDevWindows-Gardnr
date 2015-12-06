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
 
    public class AlarmController : TableController<Alarm>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            GardenrContext context = new GardenrContext();
            DomainManager = new EntityDomainManager<Alarm>(context, Request, Services);
        }

        // GET tables/Alarm
        public IQueryable<Alarm> GetAllAlarm()
        {
            return Query(); 
        }

        // GET tables/Alarm/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Alarm> GetAlarm(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Alarm/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Alarm> PatchAlarm(string id, Delta<Alarm> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Alarm
        public async Task<IHttpActionResult> PostAlarm(Alarm item)
        {
            Alarm current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Alarm/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteAlarm(string id)
        {
             return DeleteAsync(id);
        }

    }
}