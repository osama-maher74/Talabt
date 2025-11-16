using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Domain.Contracts.Presistance
{
    public interface IGenericRepositry<TEntity,TKey> 
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking=false);
        Task<TEntity?> GetByIdAsync(TKey id);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        public Task<IEnumerable<TEntity>> GetAllWithSpecsAsync(ISpesfications<TEntity, TKey> spesfication, bool withTracking = false);
        
        public Task<TEntity?> GetByIdWithSpecsAsync(ISpesfications<TEntity, TKey> spesfication);
        Task<int> GetCountAsync(ISpesfications<TEntity, TKey> spesfication);
    }
}
