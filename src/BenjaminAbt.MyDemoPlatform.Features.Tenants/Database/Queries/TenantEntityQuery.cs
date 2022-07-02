using System;
using System.Linq;
using System.Linq.Expressions;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Entities;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Queries;
public static class TenantEntityQuery
{
    public static Expression<Func<TenantEntity, bool>> WithId(PlatformTenantId tenantId)
        => tenant => tenant.Id == tenantId;

    public static Expression<Func<TenantEntity, bool>> HasUser(PlatformUserId userId)
     => tenant => tenant.TenantUserAccountAssociations
     .Any(userAssociation => userAssociation.UserAccount.Id == userId);
}
