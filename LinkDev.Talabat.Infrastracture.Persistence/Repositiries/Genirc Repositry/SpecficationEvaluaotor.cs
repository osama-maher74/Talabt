using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Domain.Common;
using LinkDev.Talabat.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.Infrastracture.Persistence.Repositiries.Genirc_Repositry
{
    public static class specficationEvaluaotor<TEntity,TKey> 
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpesfications<TEntity,TKey> spec)
        {
             var query = inputQuery;
            //where
         if (spec.Criatria!= null)
             {
             query = query.Where(spec.Criatria);
             }
            //order by
            if (spec.OrderBy != null)
             {
                 query = query.OrderBy(spec.OrderBy);
            }
            //order by desc
            else if (spec.OrderByDesc != null)
                {
                    query = query.OrderByDescending(spec.OrderByDesc);
            }

            //paging
            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            //includes
            if (spec.Includes != null && spec.Includes.Any())
            {
                 query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
             }
           

            return query;
    }

    }
}
