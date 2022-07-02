using BenjaminAbt.MyDemoPlatform.AspNetCore.Mvc.Filters;
using BenjaminAbt.MyDemoPlatform.Features.AspNetCore.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.AspNetCore.Controllers;

[ApiController]
[ModelStateValidation]
public abstract class SecurityPortalController : MyDemoPlatformPlatformBaseController { }
