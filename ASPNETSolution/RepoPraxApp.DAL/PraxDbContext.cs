using RepoPraxApp.DAL.Interfaces;
using RepoPraxApp.DAL.Migrations;
using RepoPraxApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPraxApp.DAL
{
    public class PraxDbContext : DbContext, IDbContext
    {
        public PraxDbContext() : base ("DbConnectionString")
        {
            //Enable-Migrations
            //Add-Migration InitialMigration
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PraxDbContext, MigrationConfiguration>());
            // Logib infot, kui tegemist on Debugimisega.
#if DEBUG
            Database.Log = s => Trace.Write(s);
#endif
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
    }
}
