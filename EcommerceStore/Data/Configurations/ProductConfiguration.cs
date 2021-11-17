using EcommerceStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("PRODUCT");
            builder.HasKey(product => product.ProductId);
            builder.Property(product => product.Name);
            builder.Property(product => product.Producer);
            builder.Property(product => product.Price);
            builder.Property(product => product.ImgUrl);
            builder.Property(product => product.Status);
            builder.Property(product => product.Rating);
            builder.Property(product => product.Special);
            builder.Property(product => product.SellOff);
            builder.Property(product => product.TimeSellOff);

        }
    }
}
