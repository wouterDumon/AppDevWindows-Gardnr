using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotificationAPI.Models
{
    public class Notificaties
    {
        public string ID { get; set; }
        public string TypeID { get; set; }
        public string Omschrijving { get; set; }
        public string AlarmID { get; set; }
        public string GebruikerID { get; set; }
        public string datum { get; set; }
        public string PlantID { get; set; }

    }
}