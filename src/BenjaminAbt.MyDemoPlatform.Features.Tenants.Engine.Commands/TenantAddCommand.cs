using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Engine.Commands;

public record class TenantAddCommand(
     string Name) : ICommand<PlatformTenantId>;
