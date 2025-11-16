using LinkDev.Talabat.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Infrastracture.Persistence.Data.Config.Base
{
    public class BaseEntityConfigrations<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e=>e.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
 