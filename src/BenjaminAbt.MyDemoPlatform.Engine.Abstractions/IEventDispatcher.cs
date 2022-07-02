using System.Threading;
using System.Threading.Tasks;

namespace BenjaminAbt.MyDemoPlatform.Engine.Abstractions;

public interface IEventDispatcher
{
    Task<TResponse> Send<TResponse>(ICommand<TResponse> command,
        CancellationToken cancellationToken = default);

    Task<TResponse> Get<TResponse>(IQuery<TResponse> query,
        CancellationToken cancellationToken = default);
}
