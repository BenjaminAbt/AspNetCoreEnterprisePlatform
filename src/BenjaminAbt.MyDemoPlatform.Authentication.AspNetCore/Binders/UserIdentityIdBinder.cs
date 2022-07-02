using System;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BenjaminAbt.MyDemoPlatform.Authentication.AspNetCore.Binders;

public class UserIdentityIdBinder : IModelBinder
{
    private readonly IRequestUserIdentityAccessor _userAuthenticationAccessor;

    public UserIdentityIdBinder(IRequestUserIdentityAccessor userAuthenticationAccessor)
    {
        _userAuthenticationAccessor = userAuthenticationAccessor;
    }
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);

        if (_userAuthenticationAccessor.TryGetUserIdentityId(out Guid? userIdentityId) && userIdentityId.HasValue)
        {
            bindingContext.Result = ModelBindingResult.Success(new RequestContextUserIdentity(userIdentityId.Value));
        }
        else
        {
            bindingContext.ModelState.TryAddModelError(nameof(RequestContextUserIdentity), "Unable to retreive user identity id.");
        }

        return Task.CompletedTask;
    }
}
