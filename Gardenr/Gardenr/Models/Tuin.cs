﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.Models
{
    class Tuin
    {
        public string ID { get; set; }        
        public Plant Plant { get; set; }
        public string gebruikerID { get; set; }
        public bool favoriet { get; set; }
        public int Aantal { get; set; }
        public string LaatstWater { get; set; }
        public string extra { get; set; }
        public ObservableCollection<Notificaties> Notificaties { get; set; }

        public bool historiek { get; set; }
        public string plantDatum { get; set; }
    }
}
