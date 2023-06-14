using Core.UnitOfWorkManager;
using MediatR;

namespace Core.CQRS.QueryManager;

public interface IQuery<T> : IRequest<T>
{
    public IUnitOfWork UnitOfWork { get; init; }
}
