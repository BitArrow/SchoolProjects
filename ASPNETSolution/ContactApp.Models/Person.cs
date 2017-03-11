using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual List<Contact> Contacts { get; set; } = new List<Contact>();

        #region NotMapped
        // ToExpresionBody
        public string FirstLastName => string.Format("{0} {1}", FirstName, LastName);
        public string LastFirstName => string.Format("{0} {1}", LastName, FirstName);
        #endregion
    }
}
