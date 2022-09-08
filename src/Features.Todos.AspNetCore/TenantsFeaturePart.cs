// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System.Collections.Generic;
using System.Reflection;
using BenjaminAbt.MyDemoPlatform.Features.AspNetCore.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.MyDemoPlatform.Features.Todos.AspNetCore;

public class TodoPart : MyDemoPlatformPlatformFeatureMvcPart<TodoPlatformFeature>
{
    public TodoPart(IConfigurationSection configurationSection)
         : base(new TodoPlatformFeature(configurationSection))
    { }

    public override IEnumerable<Assembly> ConfigureAutomapperAssemblies()
    {
        yield return typeof(TodoPlatformFeature).Assembly;
    }

    public override void ConfigureServices(IServiceCollection services)
    {

    }
}
