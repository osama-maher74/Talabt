using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Domain.Entites.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Infrastracture.Persistence.Identity.Config
{
    internal class ApplicationUserConfigrations:IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.DisplayName)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired(true);

            builder.HasOne(U=>U.Address)
                .WithOne(A=>A.User)
                .HasForeignKey<Address>(A=>A.UserId)
                .OnDelete(DeleteBehavior.Cascade);


        }

    }
}
