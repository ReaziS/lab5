using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FactoryProduction.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext()
        { }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Factories> Factories { get; set; }
        public virtual DbSet<PlanOfImplement> PlanOfImplement { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductTypes> ProductTypes { get; set; }
        public virtual DbSet<ReleacePlan> ReleacePlan { get; set; }

       
    }
}