// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System.Reflection;
using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BenjaminAbt.MyDemoPlatform.Engine;

public static class MediatorDispatcherDependencyInjection
{
    /// <summary>
    /// Registers MediatR as Engine Runtime
    /// </summary>
    public static IServiceCollection AddEngine(this IServiceCollection services)
    {
        Assembly currentAssembly = typeof(MediatorDispatcherDependencyInjection).Assembly;
        services.AddMediatR(config => config.RegisterServicesFromAssembly(currentAssembly));
        services.TryAddScoped<IEventDispatcher, MediatorDispatcher>(); // only add if not exists!

        return services;
    }

    /// <summary>
    /// This method registers a query type once.
    /// </summary>
    public static IServiceCollection AddEngineQuery<TQuery, TReturn, THandler>(this IServiceCollection services)
        where TQuery : class, IQuery<TReturn>
        where THandler : class, IQueryHandler<TQuery, TReturn>
    {
        services.TryAddTransient<IRequestHandler<TQuery, TReturn>, THandler>(); // add interface only once

        return services;
    }

    /// <summary>
    /// This method registers a command type once.
    /// </summary>
    public static IServiceCollection AddEngineCommand<TCommand, TReturn, THandler>(this IServiceCollection services)
        where TCommand : class, ICommand<TReturn>
        where THandler : class, ICommandHandler<TCommand, TReturn>
    {
        services.TryAddTransient<IRequestHandler<TCommand, TReturn>, THandler>(); // add interface only once

        return services;
    }
}
