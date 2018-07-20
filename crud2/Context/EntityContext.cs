using crud2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud2.Context
{ //2 
    public class EntityContext:DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options):base(options)
        {
            //Database.Migrate();//göç
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
