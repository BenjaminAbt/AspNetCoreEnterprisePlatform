// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using Microsoft.AspNetCore.Mvc.Filters;

namespace BenjaminAbt.MyDemoPlatform.AspNetCore.Mvc.Filters;

public class ModelStateValidationAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.IsNotValid(out string[]? errors))
        {
            context.Result = ErrorResponseFactory.BadRequest(errors);
        }
    }
}
