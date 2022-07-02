using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Models.AspNetCore.ModelBinders.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BenjaminAbt.MyDemoPlatform.Models.AspNetCore.ModelBinders;
public class PlatformUserIdBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
        => bindingContext.HandlePlatformModel<PlatformUserId>();
}
