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

public class MicrosoftIdentityController : SecurityPortalController
{
    private readonly IRequestUserIdentityTenantAuthAccessor _userIdentityTenantAuthAccessor;
    private readonly IEventDispatcher _eventDispatcher;
    private readonly IMapper _mapper;
    private readonly ILogger<MicrosoftIdentityController> _logger;

    public MicrosoftIdentityController(
        IRequestUserIdentityTenantAuthAccessor userIdentityTenantAuthAccessor,
        IEventDispatcher eventDispatcher, IMapper mapper,
        ILogger<MicrosoftIdentityController> logger)
    {
        _userIdentityTenantAuthAccessor = userIdentityTenantAuthAccessor;
        _eventDispatcher = eventDispatcher;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    [Route(MyDemoPlatformApiRoutes.SecurityPortal.MicrosoftIdentity.IdentityRiskStateStats)]
    public async Task<ActionResult<SecurityPortalMicrosoftIdentityRiskLevelStatsSeriesModel>> IdentityRiskStateStats(
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
        var result = await _eventDispatcher.Get(new GetMicrosoftIdentityRiskLevelStatsSeriesQuery(
            platformTenantId,
            ValueHelper.ThrowIfNull(requestModel.From),
            ValueHelper.ThrowIfNull(requestModel.To)));

        return OkMapIfNotNull<SecurityPortalMicrosoftIdentityRiskLevelStatsSeriesModel>(_mapper, result);
    }

    [HttpGet]
    [Route(MyDemoPlatformApiRoutes.SecurityPortal.MicrosoftIdentity.LatestRiskyIdentities)]
    public async Task<ActionResult<SecurityPortalMicrosoftIdentityRiskyIdentitiesModel>> LatestRiskyIdentities(
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
        var result = await _eventDispatcher.Get(new GetMicrosoftIdentityRiskyIdentitiesQuery(
            platformTenantId,
            ValueHelper.ThrowIfNull(requestModel.From),
            ValueHelper.ThrowIfNull(requestModel.To)));

        return OkMapIfNotNull<SecurityPortalMicrosoftIdentityRiskyIdentitiesModel>(_mapper, result);
    }
}
