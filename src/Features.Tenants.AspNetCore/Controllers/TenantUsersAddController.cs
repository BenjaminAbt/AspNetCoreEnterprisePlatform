// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;
using System.Threading.Tasks;
using AutoMapper;
using BenjaminAbt.MyDemoPlatform.AspNetCore.Logging;
using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Authorization.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Engine.Commands;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Routing;
using BenjaminAbt.MyDemoPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.AspNetCore.Controllers;

public class TenantUsersAddController : TenantsBaseController
{
    private readonly IRequestUserIdentityTenantAuthAccessor _userIdentityTenantAuthAccessor;
    private readonly IEventDispatcher _eventDispatcher;
    private readonly IMapper _mapper;
    private readonly ILogger<TenantUsersAddController> _logger;

    public TenantUsersAddController(
        IRequestUserIdentityTenantAuthAccessor userIdentityTenantAuthAccessor,
        IEventDispatcher eventDispatcher,
        IMapper mapper,
        ILogger<TenantUsersAddController> logger)
    {
        _userIdentityTenantAuthAccessor = userIdentityTenantAuthAccessor;
        _eventDispatcher = eventDispatcher;
        _mapper = mapper;
        _logger = logger;
    }


    [HttpPost]
    [Route(MyDemoPlatformApiRoutes.Tenants.Users.Add)]
    public async Task<ActionResult<ObjectResult<Guid>>> Add(
        [FromRoute] Guid tenantId,
        [FromBody] TenantUserAddRequestModel requestModel)
    {
        PlatformTenantId platformTenantId = new PlatformTenantId(tenantId);

        // authorization
        UserTenantAccessResult? userTenantAccessResult = await _userIdentityTenantAuthAccessor.HasTenantAccess(platformTenantId);
        if (!userTenantAccessResult.HasValue)
        {
            ControllerLoggerMessages.ForbiddenTenantAccess(_logger);
            return Forbid();
        }

        // execute
        PlatformUserId platformUserId = await _eventDispatcher.Send(new TenantUserAddCommand(platformTenantId,
            requestModel.Name));

        return new ObjectResult<Guid>(platformUserId.Value,
            new ObjectResultMetadata(DateTimeOffset.UtcNow));
    }
}
