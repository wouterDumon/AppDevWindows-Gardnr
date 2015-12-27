using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotificationAPI.Models
{
    public class Alarm
    {
        public string ID { get; set; }
        public bool Activate { get; set; }
        public int OpVoorand { get; set; }
        public int herhalen { get; set; }
        public int Snooze { get; set; }
    }
}