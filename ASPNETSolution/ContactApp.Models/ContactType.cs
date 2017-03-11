using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    public class ContactType
    {
        public int ContactTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
