using EcommerceStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Data.Configurations
{
    public class BillProductConfiguration : IEntityTypeConfiguration<BillProduct>
    {
        public void Configure(EntityTypeBuilder<BillProduct> builder)
        {
            builder.ToTable("BILLPRODUCT");
            builder.HasKey(billProduct => new { billProduct.BillId, billProduct.ProductId });
            builder.Property(billProduct => billProduct.ProductName);
            builder.Property(billProduct => billProduct.ProductPrice);
            builder.Property(billProduct => billProduct.Quantity);
            builder.Property(billProduct => billProduct.TotalProductPrice);
            builder.HasOne(billProduct => billProduct.Bill)
                .WithMany(bill => bill.Products)
                .HasForeignKey(billProduct => billProduct.BillId);
            builder.HasOne(billProduct => billProduct.Product)
                .WithMany(product => product.BillProducts)
                .HasForeignKey(billProduct => billProduct.ProductId);
        }
    }
}
