// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BenjaminAbt.MyDemoPlatform.AspNetCore.Logging;
using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Authorization.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Engine.Queries;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Routing;
using BenjaminAbt.MyDemoPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.AspNetCore.Controllers;

public class TenantUsersController : TenantsBaseController
{
    private readonly IRequestUserIdentityTenantAuthAccessor _userIdentityTenantAuthAccessor;
    private readonly IEventDispatcher _eventDispatcher;
    private readonly IMapper _mapper;
    private readonly ILogger<TenantUsersAddController> _logger;

    public TenantUsersController(
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


    [HttpGet]
    [Route(MyDemoPlatformApiRoutes.Tenants.Users.List)]
    public async Task<ActionResult<CollectionResult<TenantUserItemModel>>> List(
        [FromRoute] Guid tenantId)
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
        List<UserInfoModel> users = await _eventDispatcher.Get(new TenantUsersGetQuery(
            platformTenantId));

        List<TenantUserItemModel> map = _mapper.ProjectTo<TenantUserItemModel>(
            users.AsQueryable()).ToList();

        return new CollectionResult<TenantUserItemModel>(map,
            new CollectionResultMetadata(DateTimeOffset.UtcNow, map.Count, map.Count));
    }
}
