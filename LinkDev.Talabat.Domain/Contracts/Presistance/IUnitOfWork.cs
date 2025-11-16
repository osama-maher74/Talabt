using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Domain.Entites.Products;

namespace LinkDev.Talabat.Domain.Contracts.Presistance
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IGenericRepositry<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity :BaseEntity<TKey> 
            where TKey :IEquatable<TKey> ;
        Task<int> CompleteAsync();

    }
}
