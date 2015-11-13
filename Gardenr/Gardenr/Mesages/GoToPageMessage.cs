using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gardenr.Models;


namespace Gardenr.Mesages
{
    class GoToPageMessage
    {
        public int PageNumber { get; set; }

        public Plant SelectedPlant { get; set; }

        public Notificatie SelectedNotificatie { get; set; }

        public Tuin SelectedTuinPlant { get; set; }
    }
}
