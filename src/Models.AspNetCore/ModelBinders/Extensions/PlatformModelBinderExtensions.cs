// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BenjaminAbt.MyDemoPlatform.Models.AspNetCore.ModelBinders.Extensions;

public static class PlatformModelBinderExtensions
{
    public static Task HandlePlatformModel<T>(this ModelBindingContext bindingContext)
        where T : PlatformBaseGuid, new()
    {
        ArgumentNullException.ThrowIfNull(bindingContext);

        // get model
        string modelName = bindingContext.ModelName;
        ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        // get value
        bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
        string? value = valueProviderResult.FirstValue;
        if (string.IsNullOrEmpty(value))
        {
            return Task.CompletedTask;
        }

        // parse value
        if (!PlatformGuidFactory<T>.TryParse(value, out T? platformTenantIdValue))
        {
            bindingContext.ModelState.TryAddModelError(modelName, $"Value for {modelName} has an invalid format.");
            return Task.CompletedTask;
        }

        // set value
        bindingContext.Result = ModelBindingResult.Success(platformTenantIdValue);
        return Task.CompletedTask;
    }
}


