using Mediator;
using Microsoft.EntityFrameworkCore;
using OneContextExample.Core;
using OneContextExample.Infrastructure.Data;

namespace OneContextExample.Infrastructure.Common.Services;

internal class EntityPreserver<TEntity, TData>(DataContext context, IPublisher publisher)
    where TData : class, IEntityData<TData, TEntity>
    where TEntity : Entity
{
    public async Task<TEntity?> Get(Guid id, CancellationToken cancellationToken = default)
    {
        var courierData = await context.Set<TData>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return courierData?.ToEntity();
    }
    
    public async Task Save(TEntity entity, CancellationToken cancellationToken = default)
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

        if (context.Database.CurrentTransaction is null)
        {
            await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            await SaveInternal(entity, cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        else
        {
            await SaveInternal(entity, cancellationToken);
        }
    }

    private async Task SaveInternal(TEntity entity, CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);

        var domainEvents = (entity as IDomainEventsProvider).ExtractAll();
        for (var i = 0; i < domainEvents.Count; i++)
        {
            await publisher.Publish(domainEvents[i], cancellationToken);
        }
    }
}