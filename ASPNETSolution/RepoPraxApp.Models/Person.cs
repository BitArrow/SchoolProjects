using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPraxApp.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        [MaxLength(64)]
        public string FirstName { get; set; }
        [MaxLength(64)]
        public string LastName { get; set; }

        public virtual List<Contact> Contacts { get; set; }

        // Kui pole Getterit, siis ei pea panema NotMapped regiooni.
        //#region NotMapped
        // ToExpresionBody
        public string FirstLastName => string.Format("{0} {1}", FirstName, LastName);
        public string LastFirstName => string.Format("{0} {1}", LastName, FirstName);
        //#endregion
    }
}
