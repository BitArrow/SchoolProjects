using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace ASPNETArvestus.ViewModels
{
    public class BookingViewModel
    {
        public Client Client { get; set; }
        public SelectList ClientSelectList { get; set; }

        public Lift Lift { get; set; }
        public SelectList LiftSelectList { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
    }
}