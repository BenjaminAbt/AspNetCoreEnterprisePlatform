using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using MediatR;

namespace BenjaminAbt.MyDemoPlatform.Engine;

public class MediatorDispatcher : IEventDispatcher
{
    protected readonly IMediator _mediator;

    public MediatorDispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task<TResponse> Send<TResponse>(ICommand<TResponse> command,
        CancellationToken cancellationToken = default)
        => _mediator.Send(command, cancellationToken);

    public Task<TResponse> Get<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
        => _mediator.Send(query, cancellationToken);
}
