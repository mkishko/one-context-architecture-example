using Mediator;

namespace OneContextExample.Core;

public interface ITransactionalCommand : ITransactionalCommand<Unit>;

public interface ITransactionalCommand<out T> : ICommand<T>;
