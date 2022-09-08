// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using BenjaminAbt.MyDemoPlatform.AspNetCore.Mvc.Filters;
using BenjaminAbt.MyDemoPlatform.Features.AspNetCore.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.AspNetCore.Controllers;

[ApiController]
[ModelStateValidation]
public abstract class TenantsBaseController : MyDemoPlatformPlatformBaseController { }
