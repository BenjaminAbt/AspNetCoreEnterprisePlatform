// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.MyDemoPlatform.Authorization;

public static class PlatformPolicyExtensions
{
    public static IServiceCollection AddPlatformAuthorizationHandler<T>(
        this IServiceCollection services) where T : class, IAuthorizationHandler
    {
        services.AddScoped<IAuthorizationHandler, T>();
        return services;
    }
}
