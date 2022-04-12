using MediatR;

namespace Core.CQRS.CommandManager;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
{
}
