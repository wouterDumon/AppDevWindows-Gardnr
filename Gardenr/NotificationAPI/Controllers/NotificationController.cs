using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Azure.NotificationHubs;


namespace NotificationAPI.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public async Task Index()
        {
            

            NotificationHubClient client = NotificationHubClient.CreateClientFromConnectionString("Endpoint=sb://gardenr.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=0cxmkySgALisaXPBhX+2qfF+KP4lNduhmJ5IhIDFMRQ=", "gardnotif");

            string[] userTag = new string[2];
            userTag[0] = "username:" + "a4b81738a5dc4b4cbb941260f7824eb4";
            userTag[1] = "from:" + "a4b81738a5dc4b4cbb941260f7824eb4";
            var toast = @"<toast><visual><binding template=""ToastText01""><text id=""1"">" + "trol" + "</text></binding></visual></toast>";
            await client.SendWindowsNativeNotificationAsync(toast, userTag);

        }
    }
}