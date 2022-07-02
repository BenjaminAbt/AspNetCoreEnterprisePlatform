using MediatR;

namespace BenjaminAbt.MyDemoPlatform.Engine.Abstractions;

public interface ICommand<out TResponse> : IRequest<TResponse> { }
