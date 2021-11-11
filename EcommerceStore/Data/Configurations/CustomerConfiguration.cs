using EcommerceStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("CUSTOMER");
            builder.HasKey(customer => customer.Id);
            builder.Property(customer => customer.FullName);
            builder.Property(customer => customer.Gender);
            builder.Property(customer => customer.Point);
            builder.Property(customer => customer.BirthDay);
            builder.Property(customer => customer.Admin);
        }
    }
}
