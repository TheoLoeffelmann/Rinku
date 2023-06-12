using System;
using System.Collections.Generic;
using System.Text;

namespace Rinku.Entities
{
    using Microsoft.EntityFrameworkCore;
    using Rinku.Entities.Entities;

    public class RinkuContext : DbContext
    {
        public RinkuContext(DbContextOptions opts): base (opts) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<CatSalaries>   CatSalaries { get; set; }
        public DbSet<CatRoles> CatRoles { get; set; }
        public DbSet<Deliveries> Deliveries { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Payments> Payments { get; set; }



    }
}
