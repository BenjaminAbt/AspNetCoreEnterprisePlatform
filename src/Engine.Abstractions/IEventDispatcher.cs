// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

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
