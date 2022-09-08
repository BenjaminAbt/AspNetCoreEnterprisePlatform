// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;
using System.Linq;
using System.Linq.Expressions;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Entities;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Queries;
public static class UserAccountQuery
{
    public static Expression<Func<UserAccountEntity, bool>> WithId(PlatformUserId userId)
        => ua => ua.Id == userId;

    public static Expression<Func<UserAccountEntity, bool>> OfTenant(PlatformTenantId tenantId)
        => ua => ua.TenantUserAccountAssociations.Any(a => a.TenantId == tenantId);
}
