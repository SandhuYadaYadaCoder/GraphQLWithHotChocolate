using MediatR;

namespace Core.CQRS.CommandManager;

public class ICommandWithReturn<T> : IRequest<T>
{
}
