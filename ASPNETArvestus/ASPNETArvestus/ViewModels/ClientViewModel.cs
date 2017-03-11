using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace ASPNETArvestus.ViewModels
{
    public class ClientViewModel
    {
        public virtual Client Client { get; set; }
        public virtual ICollection<ClientType> ClientTypes { get; set; }

    }
}