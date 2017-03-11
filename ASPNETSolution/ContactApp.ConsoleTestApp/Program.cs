using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Models;
using ContactApp.DAL;

namespace ContactApp.ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new DataBaseContext();
            var p = ctx.Persons.ToList();
        }
    }
}
