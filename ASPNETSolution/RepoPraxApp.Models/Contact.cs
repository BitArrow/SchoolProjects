using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPraxApp.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        [MaxLength(125)]
        public string Value { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public int ContactTypeId { get; set; }
        public virtual ContactType ContactType { get; set; }
    }
}
