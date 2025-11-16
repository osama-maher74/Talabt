using LinkDev.Talabat.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Infrastracture.Persistence.Data.Config.Base
{
    public class BaseAuditableEntityConfigrations<TEntity, TKey> : BaseEntityConfigrations<TEntity,TKey>
        where TEntity : BaseAuditableEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

        }
    }
}
