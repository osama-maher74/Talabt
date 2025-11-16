using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Domain.Entites.Products;
using LinkDev.Talabat.Infrastracture.Persistence.Data.Config.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Infrastracture.Persistence.Data.Config.Products
{
    public class ProductConfigrations:BaseAuditableEntityConfigrations<Product,int>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
                
            builder.HasOne(product=>product.Brand)
                .WithMany()
                .HasForeignKey(product=>product.BrandId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(product=>product.Category)
                .WithMany()
                .HasForeignKey(product=>product.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);


        }
    }
}
