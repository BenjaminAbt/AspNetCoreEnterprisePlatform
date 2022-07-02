using BenjaminAbt.MyDemoPlatform.Features.AspNetCore.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.AspNetCore.Mvc;

[Authorize]
public abstract class TenantUserAuthorizedBaseController : MyDemoPlatformPlatformBaseController
{ }
