using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WINAPI.Models
{
    public class Instellingen
    {

        public int ID { get; set; }
        public Taal Taal { get; set; }
        public string Cortana { get; set; }
        public string PushNotificaties { get; set; }
    }
}