using Manufacturing.Common.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Manufacturing.Common.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await context.Set<TEntity>().AddAsync(entity)).Entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await context.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task<bool> ContainsAsync(ISpecification<TEntity> specification)
        {
            var count = await CountAsync(specification);
            return count > 0 ? true : false;
        }

        public async Task<bool> ContainsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var count = await CountAsync(predicate);
            return count > 0 ? true : false;
        }

        public async Task<int> CountAsync(ISpecification<TEntity> specification)
        {
            return (await ApplySpecification(specification)).Count();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().Where(predicate).CountAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> specification)
        {
            return await ApplySpecification(specification);
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        private async Task<IEnumerable<TEntity>> ApplySpecification(ISpecification<TEntity> spec)
        {
            return await SpecificationEvaluator<TEntity>.GetQuery(context.Set<TEntity>().AsQueryable(), spec).ToListAsync();
        }
    }
}
