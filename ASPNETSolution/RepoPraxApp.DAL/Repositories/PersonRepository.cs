using RepoPraxApp.DAL.Interfaces;
using RepoPraxApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoPraxApp.Models.Aggregate;

namespace RepoPraxApp.DAL.Repositories
{
    public class PersonRepository : EFRepository<Person>, IPersonRepository
    {
        public PersonRepository(IDbContext dbContext) : base(dbContext)
        {

        }

        public List<PersonWithContactCount> GetPersonsWithContactCount()
        {
            return DbSet.Select(p => new PersonWithContactCount() { Person = p, ContactCount = p.Contacts.Count }).ToList();
        }
    }
}
