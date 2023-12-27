using Manufacturing.Common.Domain.Entities;
using Manufacturing.Common.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Manufacturing.Common.Application.Queries;

public abstract class BaseQuery<TEntity>
    where TEntity : Entity
{
    protected readonly IUnitOfWork unitOfWork;

    protected BaseQuery(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    protected async Task<IEnumerable<TEntity>> FindBySpecificationAsync(ISpecification<TEntity> specification)
    {
        return await unitOfWork.Repository<TEntity>().Find(specification).ToListAsync();
    }
}
