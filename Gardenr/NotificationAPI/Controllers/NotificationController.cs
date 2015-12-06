using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Azure.NotificationHubs;
using System.Net;
using NotificationAPI.Models;

namespace NotificationAPI.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public async Task Index()
        {

            // var hub = new NotificationHub("notific", "Endpoint=sb://gardenrnotif.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=8bPfKiz9h4jY/e0JtAUqN/tCybd+dOtj3X/tA6zndxM=");
            Microsoft.Azure.NotificationHubs.NotificationOutcome outcome = null;
            HttpStatusCode ret = HttpStatusCode.InternalServerError;


            NotificationHubClient client = NotificationHubClient.CreateClientFromConnectionString("Endpoint=sb://gardenrnotif.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=8bPfKiz9h4jY/e0JtAUqN/tCybd+dOtj3X/tA6zndxM=", "notific");

            string[] userTag = new string[2];
            userTag[0] = "username:" + "1218636688163585";
            userTag[1] = "from:" + "1218636688163585";
            var toast = @"<toast><visual><binding template=""ToastText01""><text id=""1"">" +
                                "From " + ": HALLO DIT IS EEN TEST"  + "</text></binding></visual></toast>";
            outcome = await Notifications.Instance.Hub.SendWindowsNativeNotificationAsync(toast, userTag);
            //  var toast = @"<toast><visual><binding template=""ToastText01""><text id=""1"">" + "trol" + "</text></binding></visual></toast>";
            //   await client.SendWindowsNativeNotificationAsync(toast, userTag);
            if (outcome != null)
            {
                if (!((outcome.State == Microsoft.Azure.NotificationHubs.NotificationOutcomeState.Abandoned) ||
                    (outcome.State == Microsoft.Azure.NotificationHubs.NotificationOutcomeState.Unknown)))
                {
                    ret = HttpStatusCode.OK;
                }
            }

        }
       

    }
}