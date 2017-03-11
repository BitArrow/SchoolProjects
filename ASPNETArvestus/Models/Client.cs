using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Client
    {
        public int ClientId { get; set; }

        public int ClientTypeId { get; set; }

        [MaxLength(128)]
        public string FirstName { get; set; }

        [MaxLength(128)]
        public string LastName { get; set; }

        public virtual ClientType ClientType { get; set; }

        public virtual List<Booking> Bookings { get; set; } = new List<Booking>();

        public string FirstLastname => FirstName + " " + LastName;
        public string LastFirstname => LastName + " " + FirstName;
    }
}
