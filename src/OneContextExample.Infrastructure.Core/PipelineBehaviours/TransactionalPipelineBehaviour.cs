using Mediator;
using OneContextExample.Core;
using OneContextExample.Infrastructure.DataAccess;

namespace OneContextExample.Infrastructure.PipelineBehaviours;

internal class TransactionalPipelineBehaviour<TRequest, TResponse>(DataContext context) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ITransactionalCommand<TResponse>
{
    public async ValueTask<TResponse> Handle(
        TRequest message,
        CancellationToken cancellationToken,
        MessageHandlerDelegate<TRequest, TResponse> next)
    {
        var transaction = context.Database.CurrentTransaction;
        var newTransaction = false;
        if (transaction == null)
        {
            transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            newTransaction = true;
        }
        
        var response = await next(message, cancellationToken);

        if (newTransaction)
        {
            await transaction.CommitAsync(cancellationToken);
            await transaction.DisposeAsync();
        }
        
        return response;
    }
}