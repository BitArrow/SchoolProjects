using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Models;

namespace DAL
{
    public class DataContext : DbContext, IDbContext
    {
        public DataContext()
            : base("name=DbConnectionString")
        {
            //Database.SetInitializer(
            //    new MigrateDatabaseToLatestVersion<DataContext, MigrationConfiguration>());
            Database.SetInitializer(new DatabaseInitializer());
            base.Configuration.ProxyCreationEnabled = false;
            //Database.SetInitializer(new DatabaseInitializer());
#if DEBUG
            // Enable database loggind to trace console
            // to see output, start project in debug mode
            Database.Log = s => Trace.Write(s);
#endif
        }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseMetadata && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseMetadata)entity.Entity).CreatedAt = DateTime.Now;
                }

                ((BaseMetadata)entity.Entity).ModifiedAt = DateTime.Now;
            }

            return base.SaveChanges();
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // remove tablename pluralizing
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // remove cascade delete
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            /*
            // Identity, PK - string 
            //modelBuilder.Configurations.Add(new RoleMap());
            //modelBuilder.Configurations.Add(new UserClaimMap());
            //modelBuilder.Configurations.Add(new UserLoginMap());
            //modelBuilder.Configurations.Add(new UserMap());
            //modelBuilder.Configurations.Add(new UserRoleMap());

            // Identity, PK - int 
            modelBuilder.Configurations.Add(new RoleIntMap());
            modelBuilder.Configurations.Add(new UserClaimIntMap());
            modelBuilder.Configurations.Add(new UserLoginIntMap());
            modelBuilder.Configurations.Add(new UserIntMap());
            modelBuilder.Configurations.Add(new UserRoleIntMap());

            Precision.ConfigureModelBuilder(modelBuilder);
            */

            // convert all datetime and datetime? properties to datetime2 in ms sql
            // ms sql datetime has min value of 1753-01-01 00:00:00.000
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            /*
            // use Date type in ms sql, where [DataType(DataType.Date)] attribute is used
            modelBuilder.Properties<DateTime>()
           .Where(x => x.GetCustomAttributes(false).OfType<DataTypeAttribute>()
           .Any(a => a.DataType == DataType.Date))
           .Configure(c => c.HasColumnType("date"));*/
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
