using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Domain.Common;
using LinkDev.Talabat.Domain.Contracts;
using LinkDev.Talabat.Domain.Contracts.Presistance;
using LinkDev.Talabat.Domain.Entites.Products;
using LinkDev.Talabat.Infrastracture.Persistence.Data;
using LinkDev.Talabat.Infrastracture.Persistence.Repositiries.Genirc_Repositry;
using Microsoft.EntityFrameworkCore;


namespace LinkDev.Talabat.Infrastracture.Persistence.Repositiries
{
    internal class GenircRepositry<TEntity, TKey> : IGenericRepositry<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly StoreDbContext dbContext;

        public GenircRepositry(StoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking=false)
        {
            if (typeof(TEntity) == typeof(Product))
                return withTracking ? (IEnumerable<TEntity>)await dbContext.Set<Product>().Include(p => p.Brand).Include(p => p.Category).ToListAsync() :
                 (IEnumerable<TEntity>)await dbContext.Set<Product>().Include(p => p.Brand).Include(p => p.Category).AsNoTracking().ToListAsync();



            return withTracking ?
                await dbContext.Set<TEntity>().ToListAsync() :
                await dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
           return await dbContext.Set<TEntity>().FindAsync(id);
        }
      
        public async Task AddAsync(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
        }
        public void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllWithSpecsAsync(ISpesfications<TEntity,
            TKey> spesfication, bool withTracking = false)
        {
           return await ApplySpecification(spesfication).ToListAsync();
        }

        public async Task<TEntity?> GetByIdWithSpecsAsync(ISpesfications<TEntity, TKey> spesfication)
        {
            return await ApplySpecification(spesfication).FirstOrDefaultAsync();
        }
       
        public Task<int> GetCountAsync(ISpesfications<TEntity, TKey> spesfication)
        {
            return ApplySpecification(spesfication).CountAsync();
        }
        private IQueryable<TEntity> ApplySpecification(ISpesfications<TEntity, TKey> spesfication)
        {
            return specficationEvaluaotor<TEntity, TKey>.GetQuery(dbContext.Set<TEntity>(), spesfication);
        }
    }
}
