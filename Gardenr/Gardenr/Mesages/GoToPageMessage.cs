using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gardenr.Models;


namespace Gardenr.Mesages
{
    public class GoToPageMessage
    {
        public int PageNumber { get; set; }

        public Plant SelectedPlant { get; set; }

        public Notificaties SelectedNotificatie { get; set; }

        public TuinObject SelectedTuinPlant { get; set; }
    }
}
