using MediatR;

namespace Core.CQRS.QueryManager;

public class QueryManager : IQueryManager
{
    private readonly IMediator _mediator;

    public QueryManager(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        => await _mediator.Send<TResponse>(request, cancellationToken);

    public async Task<object?> Send(object request, CancellationToken cancellationToken = default)
        => await _mediator.Send(request, cancellationToken);
}
