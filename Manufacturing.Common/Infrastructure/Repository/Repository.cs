using Manufacturing.Common.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Manufacturing.Common.Infrastructure.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
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

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await context.Set<TEntity>().AddRangeAsync(entities);
    }

    public async Task<bool> ContainsAsync(ISpecification<TEntity> specification)
    {
        var count = await CountAsync(specification);
        return count > 0 ? true : false;
    }

    public async Task<bool> ContainsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var count = await CountAsync(predicate);
        return count > 0 ? true : false;
    }

    public async Task<int> CountAsync(ISpecification<TEntity> specification)
    {
        return await ApplySpecification(specification).CountAsync();
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await context.Set<TEntity>().Where(predicate).CountAsync();
    }

    public IQueryable<TEntity> Find(ISpecification<TEntity> specification)
    {
        return ApplySpecification(specification);
    }

    public async Task<TEntity> FindByIdAsync(int id)
    {
        return await context.Set<TEntity>().FindAsync(id);
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
