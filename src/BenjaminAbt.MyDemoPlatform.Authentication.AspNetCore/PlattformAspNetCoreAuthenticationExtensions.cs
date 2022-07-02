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
