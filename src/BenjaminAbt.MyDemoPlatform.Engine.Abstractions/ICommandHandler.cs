using MediatR;

namespace BenjaminAbt.MyDemoPlatform.Engine.Abstractions;

public interface ICommandHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
where TRequest : ICommand<TResponse>
{ }
