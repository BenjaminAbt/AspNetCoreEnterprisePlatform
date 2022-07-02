using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Models;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Engine.Queries;

public record class TenantUsersGetQuery(PlatformTenantId TenantId) : IQuery<List<UserInfoModel>>;
