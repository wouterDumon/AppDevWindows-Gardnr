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
        public string TypeID { get; set; }
        public string Omschrijving { get; set; }
        public string AlarmID { get; set; }
        public string GebruikerID { get; set; }
        public string PlantID { get; set; }
    }
}
