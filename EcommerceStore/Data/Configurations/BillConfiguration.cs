using EcommerceStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Data.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("BILL");
            builder.HasKey(bill => bill.BillId);
            builder.Property(bill => bill.AddressReceive);
            builder.Property(bill => bill.CustomerId);
            builder.Property(bill => bill.PaymentMethod);
            builder.Property(bill => bill.TotalPrice);
            builder.HasOne(bill => bill.Customer)
                .WithMany(customer => customer.Bills)
                .HasForeignKey(bill => bill.CustomerId);
        }
    }
}
