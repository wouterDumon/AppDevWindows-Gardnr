using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenrService.DataObjects
{
   public class TuinObject : EntityData
    {
        public string PlantenID { get; set; }
        public string gebruikerID { get; set; }
        public bool favoriet { get; set; }
        public int Aantal { get; set; }
        public string LaatstWater { get; set; }
        public string extra { get; set; }
        public string NotificationID { get; set; }

        public bool historiek { get; set; }
        public string plantDatum { get; set; }
    }
}
