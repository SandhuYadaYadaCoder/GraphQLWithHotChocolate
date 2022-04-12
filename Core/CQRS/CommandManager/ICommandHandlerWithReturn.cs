using MediatR;

namespace Core.CQRS.CommandManager;

public interface ICommandHandlerWithReturn<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : IRequest<TResponse>
{
}
