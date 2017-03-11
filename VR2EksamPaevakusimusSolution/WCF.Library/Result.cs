using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Library
{
    public class Result
    {
        public Status Status { get; set; }
        public string Description { get; set; }
    }


    public enum Status
    {
        //Siin võivad olla suvalised numbrid
        Ok = 20,
        NotOk = 30,
        NotAuthenticated = 50
    }
}
