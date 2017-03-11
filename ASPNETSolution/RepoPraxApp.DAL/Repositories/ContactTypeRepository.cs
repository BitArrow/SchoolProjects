﻿using RepoPraxApp.DAL.Interfaces;
using RepoPraxApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPraxApp.DAL.Repositories
{
    public class ContactTypeRepository : EFRepository<ContactType>, IContactTypeRepository
    {
        public ContactTypeRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
