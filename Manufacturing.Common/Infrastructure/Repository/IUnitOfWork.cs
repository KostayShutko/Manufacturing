using Manufacturing.Common.Domain.Entities;

namespace Manufacturing.Common.Infrastructure.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : Entity;
        Task<int> SaveChangesAsync();
    }
}
