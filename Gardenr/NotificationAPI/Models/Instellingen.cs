using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotificationAPI.Models
{
    public class Instellingen
    {
        public string ID { get; set; }
        public String TaalID { get; set; }
        public bool Cortana { get; set; }
        public bool PushNotificaties { get; set; }
    }
}