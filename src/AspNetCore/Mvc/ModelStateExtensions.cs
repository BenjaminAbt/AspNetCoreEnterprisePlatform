// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BenjaminAbt.MyDemoPlatform.AspNetCore.Mvc;

public static class ModelStateExtensions
{
    public static bool IsNotValid(this ModelStateDictionary source,
    [NotNullWhen(true)] out string[]? errorMessages)
    {
        if (!source.IsValid)
        {
            errorMessages = source.GetErrorCollection().ToArray();
            return true;
        }

        errorMessages = null;
        return false;
    }

    private static IEnumerable<string> GetErrorCollection(this ModelStateDictionary modelState)
        => modelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
}
