using System;
using System.Collections.Generic;
using System.Text;
using EcommerceStore.Data.Configurations;
using EcommerceStore.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceStore.Data
{
    public class ECommerceDbContext : IdentityDbContext<Customer, IdentityRole<Guid>, Guid>
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new BillConfiguration());
            modelBuilder.ApplyConfiguration(new BillProductConfiguration());
            modelBuilder.ApplyConfiguration(new DescriptionConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new EvaluationConfiguration());
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<BillProduct> BillProduct { get; set; }
        public DbSet<Description> Description { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Evaluation> Evaluation { get; set; }
    }
}
