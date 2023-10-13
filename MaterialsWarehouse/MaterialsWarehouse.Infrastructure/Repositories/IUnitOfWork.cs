using MaterialsWarehouse.Domain.Entities;

namespace MaterialsWarehouse.Infrastructure.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> SaveChangesAsync();
    }
}
