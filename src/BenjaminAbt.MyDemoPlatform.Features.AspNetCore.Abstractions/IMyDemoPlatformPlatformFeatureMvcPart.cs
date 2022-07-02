using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.MyDemoPlatform.Features.AspNetCore.Abstractions;

public interface IMyDemoPlatformPlatformFeatureMvcPart
{
    public Assembly[]? AutoMapperAssemblies { get; }

    public void AddServices(IServiceCollection services);
}
