using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int ClientId { get; set; }
        public int LiftId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Finish { get; set; }

        [MaxLength(1024)]
        public string Notes { get; set; }


        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        [ForeignKey("LiftId")]
        public virtual Lift Lift { get; set; }
    }
}
