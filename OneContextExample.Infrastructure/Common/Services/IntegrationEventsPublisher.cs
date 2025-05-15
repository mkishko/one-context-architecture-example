using System.Data;
using Dodo.Kafka.Outbox.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OneContextExample.Core;
using OneContextExample.Infrastructure.Data;

namespace OneContextExample.Infrastructure.Common.Services;

internal class IntegrationEventsPublisher(
    DataContext context,
    IMySqlOutboxEventRepository repository) : IIntegrationEventsPublisher
{
    public async Task Publish<T>(T integrationEvent, CancellationToken cancellationToken = default)
        where T : notnull
    {
        var currentConnection = context.Database.GetDbConnection();
        var isNewTransaction = true;
        IDbContextTransaction transaction;
        if (context.Database.CurrentTransaction is not null)
        {
            transaction = context.Database.CurrentTransaction;
            isNewTransaction = false;
        }
        else
        {
            transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        }
        
        await repository.Save(
            currentConnection,
            transaction.GetDbTransaction(),
            [integrationEvent],
            cancellationToken);

        if (isNewTransaction)
        {
            await transaction.CommitAsync(cancellationToken);
            await transaction.DisposeAsync();
        }
    }
}