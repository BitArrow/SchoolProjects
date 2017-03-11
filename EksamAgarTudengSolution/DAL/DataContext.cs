using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Models;

namespace DAL
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DbConnectionString")
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Subject> Subject { get; set; }
    }
}
