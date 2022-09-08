// Copyright � BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace BenjaminAbt.MyDemoPlatform.Authentication.AspNetCore.Binders;

public class PlatformAuthenticationBinders : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (context.Metadata.ModelType == typeof(RequestContextUserIdentity))
        {
            return new BinderTypeModelBinder(typeof(UserIdentityIdBinder));
        }

        return null!;
    }
}
