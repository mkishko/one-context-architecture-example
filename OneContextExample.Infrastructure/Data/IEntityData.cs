using OneContextExample.Core;

namespace OneContextExample.Infrastructure.Data;

public interface IEntityData<out T, TEntity>
    where T : IEntityData<T, TEntity>
    where TEntity : IEntity
{
    public Guid Id { get; }
    
    public static abstract T FromEntity(TEntity entity);

    public TEntity ToEntity();
}