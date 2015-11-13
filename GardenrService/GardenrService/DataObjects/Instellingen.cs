using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenrService.DataObjects
{
   public class Instellingen : EntityData
    {
        public string TaalID { get; set; }
        public bool Cortana { get; set; }
        public bool PushNotificaties { get; set; }
    }
}
