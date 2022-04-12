using MediatR;

namespace Core.CQRS.QueryManager;

public interface IQuery<T> : IRequest<T>
{
}
