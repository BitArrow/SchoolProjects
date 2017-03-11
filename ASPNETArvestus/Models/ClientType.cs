using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ClientType
    {
        public int ClientTypeId { get; set; }

        [MaxLength(128)]
        public string TypeName { get; set; }

        public virtual List<Client> Clients { get; set; } = new List<Client>();
    }
}
