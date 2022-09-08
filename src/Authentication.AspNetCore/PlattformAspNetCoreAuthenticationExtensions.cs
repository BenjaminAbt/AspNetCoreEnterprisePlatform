// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.MyDemoPlatform.Authentication.AspNetCore;
public static class PlatformAspNetCoreAuthenticationExtensions
{
    public static IServiceCollection AddPlatformAspNetCoreAuthentication(this IServiceCollection services)
    {
        services.AddSingleton<IRequestUserIdentityAccessor, RequestUserIdentityHttpContextAccessor>();
        return services;
    }
}
