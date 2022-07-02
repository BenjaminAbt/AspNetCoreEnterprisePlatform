using MediatR;

namespace BenjaminAbt.MyDemoPlatform.Engine.Abstractions;

public interface IQueryHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IQuery<TResponse>
{ }
