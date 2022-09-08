// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;
using System.Collections.Generic;
using BenjaminAbt.MyDemoPlatform.Models.AspNetCore.ModelBinders;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace BenjaminAbt.MyDemoPlatform.Models.AspNetCore;

public class MyDemoPlatformModelsBinderProvider : IModelBinderProvider
{
    public static IReadOnlyDictionary<Type, Type> _map = new Dictionary<Type, Type>()
    {
        {  typeof(PlatformTenantId) ,typeof(PlatformTenantIdBinder) },
        {  typeof(PlatformUserId) ,typeof(PlatformUserIdBinder) },
    };

    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (_map.TryGetValue(context.Metadata.ModelType, out Type binderType))
        {
            return new BinderTypeModelBinder(binderType);
        }

        return null;
    }
}
