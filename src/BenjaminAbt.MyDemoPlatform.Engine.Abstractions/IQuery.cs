using MediatR;

namespace BenjaminAbt.MyDemoPlatform.Engine.Abstractions;

public interface IQuery<out TResponse> : IRequest<TResponse> { }
