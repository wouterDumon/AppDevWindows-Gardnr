using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenrService.DataObjects
{
    public class NieuwsItem : EntityData
    {
        public string Titel { get; set; }
        public string Description { get; set; }
    }
}
