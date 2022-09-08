// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.MyDemoPlatform.Features.AspNetCore.Abstractions;

[Authorize]
public abstract class MyDemoPlatformPlatformBaseController : Controller
{
    public ActionResult<T> OkMapIfNotNull<T>(IMapper mapper, object? value)
    {
        if (value is null)
        {
            return NotFound();
        }

        return Ok(mapper.Map<T>(value));
    }
}
