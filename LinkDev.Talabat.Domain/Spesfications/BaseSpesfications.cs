using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Domain.Contracts;

namespace LinkDev.Talabat.Domain.Spesfications
{
    public class BaseSpesfications<TEntity, TKey> : ISpesfications<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public Expression<Func<TEntity,bool>>? Criatria { get; set; }=null;
        public List<Expression<Func<TEntity, object>>>? Includes { get; set; } = new ();
        public Expression<Func<TEntity, object>>? OrderBy { get; set ; }=null;
        public Expression<Func<TEntity, object>>? OrderByDesc { get ; set ; }=null;
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 0;
        public bool IsPagingEnabled { get; set; } = false;

        public BaseSpesfications()
        {
           // Includes=new List<Expression<Func<TEntity, object>>>();
        }

        public BaseSpesfications(TKey id)
        {
            Criatria = E => E.Id.Equals(id);

        }

        public BaseSpesfications(Expression<Func<TEntity, bool>>? CriatriaExpression)
        {
            Criatria = CriatriaExpression;

        }
        private protected void Addpaging(int skip,int take)
        {
            IsPagingEnabled = true;
            Skip = skip;
            Take = take;
        }


    }
}
