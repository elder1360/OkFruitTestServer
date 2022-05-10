using Core.Entities;
using Core.Interfaces;
using Infractructure.DAL.EfEntityConfigurations;
using Infractructure.DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Metadata;

namespace Infractructure.DAL
{
    public class OkFruitCtx : DbContext
    {
        

        public OkFruitCtx(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<UnitType>? UnitTypes { get; set; }
        public DbSet<Purchase>? Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OkFruitCtx).Assembly);
            modelBuilder.Seed();    
        }
    }
}