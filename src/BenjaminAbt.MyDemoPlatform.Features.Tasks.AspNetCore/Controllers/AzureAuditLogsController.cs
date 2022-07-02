using System;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.AspNetCore.Logging;
using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Engine;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Authorization.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;
using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Routing;
using BenjaminAbt.MyDemoPlatform.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.AspNetCore.Controllers;

public class AzureAuditLogsController : SecurityPortalController
{
    private readonly IRequestUserIdentityTenantAuthAccessor _userIdentityTenantAuthAccessor;
    private readonly IEventDispatcher _eventDispatcher;
    private readonly IMapper _mapper;
    private readonly ILogger<AzureAuditLogsController> _logger;

    public AzureAuditLogsController(
        IRequestUserIdentityTenantAuthAccessor userIdentityTenantAuthAccessor,
        IEventDispatcher eventDispatcher, IMapper mapper,
        ILogger<AzureAuditLogsController> logger)
    {
        _userIdentityTenantAuthAccessor = userIdentityTenantAuthAccessor;
        _eventDispatcher = eventDispatcher;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    [Route(MyDemoPlatformApiRoutes.SecurityPortal.AzureAuditLogs.TopRequestedRolesStats)]
    public async Task<ActionResult<SecurityPortalAzureAuditLogsTopRequestedRoleCountStatsModel>> TopRequestedRolesStats(
        [FromRoute] Guid tenantId,
        [FromQuery] TimeRangeOnlyQueryRequestModel requestModel)
    {

        PlatformTenantId platformTenantId = new(tenantId);

        // authorization
        UserTenantAccessResult? userTenantAccessResult = null;
        if (!userTenantAccessResult.HasValue)
        {
            ControllerLoggerMessages.ForbiddenTenantAccess(_logger);
            return Forbid();
        }

        // data
        var result = await _eventDispatcher.Get(new GetAzureAuditLogsTopRequestedRolesStatsQuery(
            new PlatformTenantId(tenantId),
            ValueHelper.ThrowIfNull(requestModel.From),
            ValueHelper.ThrowIfNull(requestModel.To)));

        return OkMapIfNotNull<SecurityPortalAzureAuditLogsTopRequestedRoleCountStatsModel>(
            _mapper, result);
    }
}

