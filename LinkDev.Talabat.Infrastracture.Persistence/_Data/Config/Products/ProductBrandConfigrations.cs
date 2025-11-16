using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Domain.Entites.Products;
using LinkDev.Talabat.Infrastracture.Persistence.Data.Config.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Infrastracture.Persistence.Data.Config.Products
{
    public class ProductBrandConfigrations:BaseAuditableEntityConfigrations<ProductBrand,int>
    {
        public override void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            base.Configure(builder);
            builder.Property(pb => pb.Name)
                .IsRequired()
                .HasMaxLength(100);
        }

    }
}
