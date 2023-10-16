using Manufacturing.Common.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MaterialsWarehouse.Infrastructure.Repositories
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

        public void AddRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().AddRange(entities);
        }

        public bool Contains(ISpecification<TEntity> specification)
        {
            return Count(specification) > 0 ? true : false;
        }

        public bool Contains(Expression<Func<TEntity, bool>> predicate)
        {
            return Count(predicate) > 0 ? true : false;
        }

        public int Count(ISpecification<TEntity> specification)
        {
            return ApplySpecification(specification).Count();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate).Count();
        }

        public IEnumerable<TEntity> Find(ISpecification<TEntity> specification)
        {
            return ApplySpecification(specification);
        }

        public TEntity FindById(int id)
        {
            return context.Set<TEntity>().Find(id);
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

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            return SpecificationEvaluator<TEntity>.GetQuery(context.Set<TEntity>().AsQueryable(), spec);
        }
    }
}
