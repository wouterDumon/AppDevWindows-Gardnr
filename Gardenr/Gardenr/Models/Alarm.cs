﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.Models
{
    public class Alarm
    {
        public int ID { get; set; }
        public bool Activate { get; set; }
        public int OpVoorand { get; set; }
        public int Snooze { get; set; }
    }
}