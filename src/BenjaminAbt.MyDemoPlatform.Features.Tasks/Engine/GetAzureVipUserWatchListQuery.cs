using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Models;
using MediatR;

namespace BenjaminAbt.MyDemoPlatform.Features.SecurityPortal.Engine;

public record class GetAzureVipUserWatchListQuery(PlatformTenantId TenantId) : IQuery<Unit?>;
