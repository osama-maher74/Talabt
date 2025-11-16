using System.Linq.Expressions;

namespace LinkDev.Talabat.Domain.Contracts
{
    public interface ISpesfications<TEntity,TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public Expression<Func<TEntity,bool>>? Criatria { get;set; }

        public List<Expression<Func<TEntity, object>>> Includes { get;set; }

        public Expression<Func<TEntity,object>>? OrderBy { get;set; }
        public Expression<Func<TEntity,object>>? OrderByDesc { get;set; }

        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPagingEnabled { get; set; }
    }
}
