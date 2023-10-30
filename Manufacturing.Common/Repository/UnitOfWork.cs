using Manufacturing.Common.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Manufacturing.Common.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;
        private Hashtable repositories;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : Entity
        {
            if (repositories == null)
                repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                        .MakeGenericType(typeof(TEntity)), context);

                repositories.Add(type, repositoryInstance);
            }

            return repositories[type] as IRepository<TEntity>;
        }

        public async Task CommitAsync() => await context.SaveChangesAsync();

        public void BeginTransaction() => context.Database.BeginTransaction();

        public void CommitTransaction() => context.Database.CommitTransaction();

        public void RollbackTransaction() => context.Database.RollbackTransaction();

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
