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
            builder.Property(bill => bill.UserName);
            builder.Property(bill => bill.Thon);
            builder.Property(bill => bill.Xa);
            builder.Property(bill => bill.Huyen);
            builder.Property(bill => bill.Tinh);
            builder.Property(bill => bill.PhoneNumber);
            builder.Property(bill => bill.CustomerId);
            builder.Property(bill => bill.PaymentMethod);
            builder.Property(bill => bill.TotalPrice);
            builder.HasOne(bill => bill.Customer)
                .WithMany(customer => customer.Bills)
                .HasForeignKey(bill => bill.CustomerId);
        }
    }
}
