// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.MyDemoPlatform.Features.AspNetCore.Abstractions;

public interface IMyDemoPlatformPlatformFeatureMvcPart
{
    public Assembly[]? AutoMapperAssemblies { get; }

    public void AddServices(IServiceCollection services);
}
