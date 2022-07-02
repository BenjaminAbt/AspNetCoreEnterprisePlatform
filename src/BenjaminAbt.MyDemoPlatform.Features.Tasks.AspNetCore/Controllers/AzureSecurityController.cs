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

public class AzureSecurityController : SecurityPortalController
{
    private readonly IRequestUserIdentityTenantAuthAccessor _userIdentityTenantAuthAccessor;
    private readonly IEventDispatcher _eventDispatcher;
    private readonly IMapper _mapper;
    private readonly ILogger<AzureSecurityController> _logger;

    public AzureSecurityController(
        IRequestUserIdentityTenantAuthAccessor userIdentityTenantAuthAccessor,
        IEventDispatcher eventDispatcher, IMapper mapper,
        ILogger<AzureSecurityController> logger)
    {
        _userIdentityTenantAuthAccessor = userIdentityTenantAuthAccessor;
        _eventDispatcher = eventDispatcher;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    [Route(MyDemoPlatformApiRoutes.SecurityPortal.AzureSecurity.CurrentScore)]
    public async Task<ActionResult<TimeScorePointModel>> CurrentScore(
        [FromRoute] Guid tenantId,
        [FromQuery] TimeRangeOnlyQueryRequestModel requestModel)
    {
        PlatformTenantId platformTenantId = new(tenantId);

        // authorization
        UserTenantAccessResult? userTenantAccessResult = await _userIdentityTenantAuthAccessor.HasTenantAccess(platformTenantId);
        if (!userTenantAccessResult.HasValue)
        {
            ControllerLoggerMessages.ForbiddenTenantAccess(_logger);
            return Forbid();
        }

        // data
        var result = await _eventDispatcher.Get(new GetAzureSecurityCurrentScoreQuery(
            platformTenantId,
            ValueHelper.ThrowIfNull(requestModel.From),
            ValueHelper.ThrowIfNull(requestModel.To)));

        return OkMapIfNotNull<TimeScorePointModel>(_mapper, result);
    }

    [HttpGet]
    [Route(MyDemoPlatformApiRoutes.SecurityPortal.AzureSecurity.OvertimeScore)]
    public async Task<ActionResult<TimeScoreSeriesModel>> OvertimeScore(
        [FromRoute] Guid tenantId,
        [FromQuery] TimeRangeOnlyQueryRequestModel requestModel)
    {
        PlatformTenantId platformTenantId = new(tenantId);

        // authorization
        UserTenantAccessResult? userTenantAccessResult = await _userIdentityTenantAuthAccessor.HasTenantAccess(platformTenantId);
        if (!userTenantAccessResult.HasValue)
        {
            ControllerLoggerMessages.ForbiddenTenantAccess(_logger);
            return Forbid();
        }

        // data
        var result = await _eventDispatcher.Get(
            new GetAzureSecurityOvertimeScoreQuery(
            platformTenantId,
            ValueHelper.ThrowIfNull(requestModel.From),
            ValueHelper.ThrowIfNull(requestModel.To)));

        return OkMapIfNotNull<TimeScoreSeriesModel>(_mapper, result);
    }
}
