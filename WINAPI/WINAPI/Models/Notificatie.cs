using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WINAPI.Models
{
    public class Notificatie
    {
        public int ID { get; set; }
        public int Type { get; set; }
        public int GebruikerID { get; set; }
        public int NotificatieID { get; set; }
        public string Omschrijving { get; set; }
        public string Datum { get; set; }
        public string uur { get; set; }
        public string activate { get; set; }
        public int X_op_voorhand { get; set; }
        public int Snooze { get; set; }
    }
}