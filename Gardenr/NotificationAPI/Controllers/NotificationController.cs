using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Azure.NotificationHubs;
using System.Net;
using NotificationAPI.Models;
using Microsoft.WindowsAzure.MobileServices;


namespace NotificationAPI.Controllers
{
    public class NotificationController : Controller
    {
        public static Microsoft.WindowsAzure.MobileServices.MobileServiceClient MobileService = new Microsoft.WindowsAzure.MobileServices.MobileServiceClient("https://gardenr2.azure-mobile.net/",
  "DMHwnJmHwPivFxaTWjDNXjzAxykHpq92"
     );
        private MobileServiceCollection<Notificaties, Notificaties> items;
        private MobileServiceCollection<Plant, Plant> itemsplant;
        private IMobileServiceTable<Notificaties> todoTable;
        private IMobileServiceTable<Plant> todoplant;
        // GET: Notification
        public async Task Index()
        {
            todoTable = MobileService.GetTable<Notificaties>();
            todoplant = MobileService.GetTable<Plant>();
            // var hub = new NotificationHub("notific", "Endpoint=sb://gardenrnotif.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=8bPfKiz9h4jY/e0JtAUqN/tCybd+dOtj3X/tA6zndxM=");
            //HttpStatusCode ret = HttpStatusCode.InternalServerError;


            items = await todoTable.ToCollectionAsync();
            DateTime t = DateTime.Now;
            string vandaag = t.Day + "/" + t.Month + "/" + t.Year;
            foreach (Notificaties n in items) {
                if (n.datum == vandaag) {
                    string id = n.GebruikerID;
                    string message = n.Omschrijving;
                    string plantnaam = await getplantnaam(n.PlantID);
                    await dosomething(id, message, plantnaam);

                }
            }           
        }

        private async Task<string> getplantnaam(string plantID)
        {
            itemsplant = await todoplant.ToCollectionAsync();
            foreach (Plant p in itemsplant) {
                if (p.ID == plantID) {
                    return p.Naam;
                }
            }

            return "";
        }

        private async Task dosomething(string id, string message, string plantnaam)
        {
            Microsoft.Azure.NotificationHubs.NotificationOutcome outcome = null;

            NotificationHubClient client = NotificationHubClient.CreateClientFromConnectionString("Endpoint=sb://gardenrnotif.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=8bPfKiz9h4jY/e0JtAUqN/tCybd+dOtj3X/tA6zndxM=", "notific");

            string[] userTag = new string[2];
            userTag[0] = "username:" + id;
            userTag[1] = "from:" + id;
            string send =plantnaam+ " Heeft je attentie nodig"+ "\n" + message;

            try
            {
                //windows
                var toast = @"<toast><visual><binding template=""ToastText01""><text id=""1"">" + send +"</text></binding></visual></toast>";
                outcome = await Notifications.Instance.Hub.SendWindowsNativeNotificationAsync(toast, userTag);

                // Android
                var notif = "{ \"data\" : {\"message\":\"" + send + "\"}}";
                outcome = await Notifications.Instance.Hub.SendGcmNativeNotificationAsync(notif, userTag);
                //  var toast = @"<toast><visual><binding template=""ToastText01""><text id=""1"">" + "trol" + "</text></binding></visual></toast>";
                //   await client.SendWindowsNativeNotificationAsync(toast, userTag);
            }
            catch (Exception ex)
            {

            }
        }

        }

  
}