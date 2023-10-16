﻿using Manufacturing.Common.Domain;
using MaterialsWarehouse.Infrastructure.Database;
using System.Collections;

namespace MaterialsWarehouse.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MaterialsContext context;
        private Hashtable _repositories;

        public UnitOfWork(MaterialsContext context)
        {
            this.context = context;
        }

        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                        .MakeGenericType(typeof(TEntity)), context);

                _repositories.Add(type, repositoryInstance);
            }

            return _repositories[type] as IRepository<TEntity>;
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
