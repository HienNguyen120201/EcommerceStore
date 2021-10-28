using EcommerceStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Data.Configurations
{
    public class DescriptionConfiguration : IEntityTypeConfiguration<Description>
    {
        public void Configure(EntityTypeBuilder<Description> builder)
        {
            builder.ToTable("DESCRIPTION");
            builder.HasKey(desc => desc.DescId);
            builder.Property(desc => desc.Desc);
            builder.Property(desc => desc.ImgUrl);
            builder.Property(desc => desc.ProductId);
            builder.HasOne(desc => desc.Product)
                .WithMany(product => product.Desc)
                .HasForeignKey(desc => desc.ProductId);
        }
    }
}
