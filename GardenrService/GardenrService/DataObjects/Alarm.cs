using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenrService.DataObjects
{
   public class Alarm : EntityData
    {

        public bool Activate { get; set; }
        public int OpVoorand { get; set; }
        public int Snooze { get; set; }
    }
}
