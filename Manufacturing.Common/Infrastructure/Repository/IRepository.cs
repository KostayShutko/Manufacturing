using System.Linq.Expressions;

namespace Manufacturing.Common.Infrastructure.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task<bool> ContainsAsync(ISpecification<TEntity> specification);

        Task<bool> ContainsAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> CountAsync(ISpecification<TEntity> specification);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Find(ISpecification<TEntity> specification);

        Task<TEntity> FindByIdAsync(int id);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
    }
}
