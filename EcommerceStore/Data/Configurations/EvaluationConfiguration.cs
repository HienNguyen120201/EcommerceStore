using EcommerceStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Data.Configurations
{
    public class EvaluationConfiguration : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder.ToTable("EVALUATION");
            builder.HasKey(eval => eval.EvalID);
            builder.Property(eval => eval.Comment);
            builder.Property(eval => eval.CustomerId);
            builder.Property(eval => eval.EvalTime);
            builder.Property(eval => eval.ProductId);
            builder.Property(eval => eval.Rating);
            builder.HasOne(eval => eval.Product)
                .WithMany(product => product.Evaluations)
                .HasForeignKey(eval => eval.ProductId);
            builder.HasOne(eval => eval.Customer)
                .WithMany(customer => customer.Evaluations)
                .HasForeignKey(eval => eval.CustomerId);
        }
    }
}
