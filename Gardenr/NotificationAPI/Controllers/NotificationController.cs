﻿using System;
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
        private MobileServiceCollection<Gebruiker, Gebruiker> itemsgebruiker;
        private MobileServiceCollection<Alarm, Alarm> itemsalarm;
        private IMobileServiceTable<Alarm> tableAlarm;
        private IMobileServiceTable<Gebruiker> todogebruiker;
        private MobileServiceCollection<Instellingen, Instellingen> itemsInstellingen;
        private IMobileServiceTable<Instellingen> todoInstellingen;
        private IMobileServiceTable<Plant> todoplant;
        // GET: Notification
        public async Task Index()
        {
            todoTable = MobileService.GetTable<Notificaties>();
            todoplant = MobileService.GetTable<Plant>();
            todogebruiker = MobileService.GetTable<Gebruiker>();
            todoInstellingen = MobileService.GetTable<Instellingen>();
            tableAlarm = MobileService.GetTable<Alarm>();
            // var hub = new NotificationHub("notific", "Endpoint=sb://gardenrnotif.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=8bPfKiz9h4jY/e0JtAUqN/tCybd+dOtj3X/tA6zndxM=");
            //HttpStatusCode ret = HttpStatusCode.InternalServerError;

            itemsalarm = await tableAlarm.ToCollectionAsync();
            items = await todoTable.ToCollectionAsync();

            itemsgebruiker = await todogebruiker.ToCollectionAsync();
            itemsInstellingen = await todoInstellingen.ToCollectionAsync();
            DateTime t = DateTime.Now;
            string vandaag = t.Day + "/" + t.Month + "/" + t.Year;
            foreach (Notificaties n in items) {
                if (n.datum.Equals(vandaag)) {
                    foreach (Alarm mijnalarm in itemsalarm)
                    {
                        if (mijnalarm.ID.Equals(n.AlarmID))
                        {
                            if (mijnalarm.Activate) {


                          
                            string id = n.GebruikerID;
                    string message = n.Omschrijving;
                    string plantnaam = await getplantnaam(n.PlantID);
                    foreach (Gebruiker gb in itemsgebruiker) {
                        if (gb.ID.Equals(n.GebruikerID)) {
                            foreach (Instellingen ins in itemsInstellingen) {
                                if (ins.ID.Equals(gb.InstellingenID)) {
                                    if (ins.PushNotificaties == true)
                                    {                                      
                                        await dosomething(id, message, plantnaam);
                                    }
                                }

                              
                            }
                        }
                    }


                            }
                            else {

                            }
                        }
                    }

                }
                else
                {
                    //Datum niet vandaag
              

                    foreach (Alarm mijnalarm in itemsalarm) {
                        if (mijnalarm.ID.Equals(n.AlarmID)) {
                            //ALARM GEVONDEN 
                            int herhalen = mijnalarm.herhalen;
                            String datum = n.datum;
                            String[] df = datum.Split('/');

                            DateTime tt = new DateTime(Int32.Parse(df[2]), Int32.Parse(df[1]), Int32.Parse(df[0]));

                            for (int i = 0; i < 5; i++) {
                              
                               tt = tt.AddDays(herhalen);
                                string vandaagintoekomst = tt.Day + "/" + tt.Month + "/" + tt.Year;                                
                             
                                if (vandaag.Equals(vandaagintoekomst))
                                {
                                    string id = n.GebruikerID;
                                    string message = n.Omschrijving;
                                    string plantnaam = await getplantnaam(n.PlantID);
                                    foreach (Gebruiker gb in itemsgebruiker)
                                    {
                                        if (gb.ID.Equals(n.GebruikerID))
                                        {
                                            foreach (Instellingen ins in itemsInstellingen)
                                            {
                                                if (ins.ID.Equals(gb.InstellingenID))
                                                {
                                                    if (ins.PushNotificaties == true)
                                                    {
                                                        n.datum = vandaagintoekomst;
                                                        await updatealarm(mijnalarm);
                                                        n.AlarmID = mijnalarm.ID; 
                                                        await updatenotificatie(n);           
                                                        await dosomething(id, message, plantnaam);
                                                    }
                                                }                                       
                                            }
                                        }
                                    }




                                }
                            }


                        }

                    }

                                }
            }
        }

        private async Task updatenotificatie(Notificaties n)
        {
            await todoTable.DeleteAsync(n);
            await todoTable.InsertAsync(n);
        }

        private async Task updatealarm(Alarm mijnalarm)
        {
            await tableAlarm.DeleteAsync(mijnalarm);
            mijnalarm.Activate = true;
            await tableAlarm.InsertAsync(mijnalarm);

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
                var toast = @"<toast><visual><binding template=""ToastText01""><text id=""1"">" + send + "</text></binding></visual></toast>";
                outcome = await Notifications.Instance.Hub.SendWindowsNativeNotificationAsync(toast, userTag);
            } catch (Exception ex) { Exception mijnexceptie = ex; }
           
        }

     
    }

  
}