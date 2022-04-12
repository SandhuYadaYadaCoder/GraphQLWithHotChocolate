using MediatR;

namespace Core.CQRS.CommandManager;

public interface ICommandManager
{
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    Task<object?> Send(object request, CancellationToken cancellationToken = default);
}
