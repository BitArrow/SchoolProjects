using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPraxApp.Models
{
    public class ContactType
    {
        public int ContactTypeId { get; set; }
        [MaxLength(64)]
        public string TypeName { get; set; }

        public virtual List<Contact> Contacts { get; set; } 
    }
}
