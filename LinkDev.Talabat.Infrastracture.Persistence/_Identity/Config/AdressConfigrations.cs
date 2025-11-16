using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Domain.Entites.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Infrastracture.Persistence._Identity.Config
{
    public class AdressConfigrations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
           builder.Property(nameof(Address.Id)).ValueGeneratedOnAdd();
            builder.Property(nameof(Address.FirstName)).HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(nameof(Address.LastName)).HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(nameof(Address.Street)).HasColumnType("varchar");
            builder.Property(nameof(Address.City)).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(nameof(Address.Country)).HasColumnType("varchar").HasMaxLength(50);

            builder.ToTable("Adresses");
        }
    }
}
