using Manufacturing.Common.Domain.Entities;
using Manufacturing.Common.Infrastructure.Repository;

namespace Manufacturing.Common.Application.Commands;

public abstract class BaseCommand<TEntity>
    where TEntity : Entity
{
    protected readonly IUnitOfWork unitOfWork;

    protected BaseCommand(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    protected async Task<TEntity> FindByIdAsync(int entityId)
    {
        return  await unitOfWork.Repository<TEntity>().FindByIdAsync(entityId);
    }

    protected IQueryable<TEntity> FindBySpecification(ISpecification<TEntity> specification)
    {
        return unitOfWork.Repository<TEntity>().Find(specification);
    }

    protected async Task<TEntity> SaveChangesAsync(TEntity entity)
    {
        if (entity.IsNew())
        {
            var addedEntity = await unitOfWork.Repository<TEntity>().AddAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return addedEntity;
        }

        unitOfWork.Repository<TEntity>().Update(entity);
        await unitOfWork.SaveChangesAsync();
        return entity;
    }
}
