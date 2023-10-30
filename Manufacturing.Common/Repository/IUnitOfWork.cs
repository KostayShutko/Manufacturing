﻿using Manufacturing.Common.Domain;

namespace Manufacturing.Common.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : Entity;
        Task<int> SaveChangesAsync();
    }
}
