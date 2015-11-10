using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenrService.DataObjects
{
    public class Notificaties : EntityData
    {
        public TypeC TypeId { get; set; }
        public string Omschrijving { get; set; }
        public Alarm Alarm { get; set; }
        public Gebruiker GebruikerID { get; set; }
        public Plant Plant { get; set; }
    }
}
