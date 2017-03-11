using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ASPNETArvestus.ViewModels
{
    public class LiftViewModel
    {
        public Lift Lift { get; set; }

        public IEnumerable<Booking> Bookings { get; set; } = new List<Booking>();
    }
}