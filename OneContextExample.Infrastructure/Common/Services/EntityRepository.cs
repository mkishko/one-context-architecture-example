using Microsoft.EntityFrameworkCore;
using OneContextExample.Core;
using OneContextExample.Infrastructure.Data;

namespace OneContextExample.Infrastructure.Common.Services;

internal abstract class EntityRepository<TEntity>(IDomainEventsDispatcher dispatcher)
    where TEntity : Entity
{
    protected abstract Task SaveEntity(TEntity entity, CancellationToken cancellationToken = default);
    
    public async Task Save(TEntity entity, CancellationToken cancellationToken = default)
    {
        await SaveEntity(entity, cancellationToken);
        await dispatcher.Dispatch(entity, cancellationToken);
    }
}

internal class EntityRepository<TEntity, TData>(DataContext context, IDomainEventsDispatcher dispatcher)
    : EntityRepository<TEntity>(dispatcher)
    where TData : class, IEntityData<TData, TEntity>
    where TEntity : Entity
{
    public virtual async Task<TEntity?> Get(Guid id, CancellationToken cancellationToken = default)
    {
        var courierData = await context.Set<TData>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return courierData?.ToEntity();
    }

    protected override async Task SaveEntity(TEntity entity, CancellationToken cancellationToken = default)
    {
        var data = TData.FromEntity(entity);
        var local = context.Set<TData>().Local.FirstOrDefault(e => e.Id == entity.Id);
        if (local != null)
        {
            context.Entry(local).CurrentValues.SetValues(data);
        }
        else
        {
            context.Update(data);
        }
        
        await context.SaveChangesAsync(cancellationToken);
    }
}