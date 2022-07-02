using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Models;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Authorization.Abstractions;

public interface IRequestUserIdentityTenantAuthAccessor
{
    Task<UserTenantAccessResult?> HasTenantAccess(PlatformTenantId platformTenantId);
}
