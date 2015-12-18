using Gardenr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.Mesages
{
    class NotificatieMessage
    {
        public Notificaties SelectedNotificatie { get; set; }

        public Tuin SelectedTuinPlant { get; set; }
    }
}
