using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Lift
    {
        public int LiftId { get; set; }

        [MaxLength(128)]
        public string LiftNumber { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }

        public double MaxWeight { get; set; }

        public virtual List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
