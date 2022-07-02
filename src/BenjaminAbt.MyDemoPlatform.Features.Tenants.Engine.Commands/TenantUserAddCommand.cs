using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Models;
using MediatR;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Engine.Commands;

public record class TenantUserAddCommand(
     PlatformTenantId PlatformTenantId,
     string Name) : ICommand<PlatformUserId>;
