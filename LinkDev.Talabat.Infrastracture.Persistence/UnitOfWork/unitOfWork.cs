using System.Collections.Concurrent;
using LinkDev.Talabat.Domain.Common;
using LinkDev.Talabat.Domain.Contracts.Presistance;
using LinkDev.Talabat.Infrastracture.Persistence.Data;
using LinkDev.Talabat.Infrastracture.Persistence.Repositiries;

namespace LinkDev.Talabat.Infrastracture.Persistence.UnitOfWork
{
    public class unitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext dbContext;
        private readonly ConcurrentDictionary<string, object> repositories; 

        public unitOfWork(StoreDbContext dbContext)
        {
            this.dbContext = dbContext;
            repositories= new ();


        }

        public IGenericRepositry<TEntity, TKey> GetRepository<TEntity, TKey>()
             where TEntity : BaseEntity<TKey>
             where TKey : IEquatable<TKey>
        {
           return (IGenericRepositry<TEntity, TKey>)repositories.GetOrAdd(typeof(TEntity).Name, new GenircRepositry<TEntity, TKey>(dbContext));
        }

        public Task<int> CompleteAsync()
        {
           return dbContext.SaveChangesAsync();
        }

        public ValueTask DisposeAsync()
        {
            return dbContext.DisposeAsync();

        }

        
    }
}
