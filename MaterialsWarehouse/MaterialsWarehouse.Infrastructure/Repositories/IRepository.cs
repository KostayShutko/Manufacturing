using System.Linq.Expressions;

namespace MaterialsWarehouse.Infrastructure.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity FindById(int id);

        IEnumerable<TEntity> Find(ISpecification<TEntity> specification);

        Task<TEntity> AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        bool Contains(ISpecification<TEntity> specification);
        bool Contains(Expression<Func<TEntity, bool>> predicate);

        int Count(ISpecification<TEntity> specification);
        int Count(Expression<Func<TEntity, bool>> predicate);
    }
}
