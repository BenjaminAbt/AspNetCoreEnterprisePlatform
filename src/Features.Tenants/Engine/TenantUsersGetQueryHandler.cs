// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.MyDemoPlatform.Database.SqlServer;
using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Database.Repositories;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Engine.Queries;
using BenjaminAbt.MyDemoPlatform.Features.Tenants.Models;
using BenjaminAbt.MyDemoPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Engine;

public class TenantUsersGetQueryHandler : IQueryHandler<TenantUsersGetQuery, List<UserInfoModel>>
{
    private readonly UserAccountsRepository _userAccountsRepository;

    public TenantUsersGetQueryHandler(UserAccountsRepository userAccountsRepository)
    {
        _userAccountsRepository = userAccountsRepository;
    }

    public async Task<List<UserInfoModel>> Handle(TenantUsersGetQuery request, CancellationToken cancellationToken)
    {
        PlatformTenantId platformTenantId = request.TenantId;

        List<UserInfoModel> users = await _userAccountsRepository
                .QueryUsers(platformTenantId, DbTrackingOptions.Disabled)
                .Select(u => new UserInfoModel(u.Id, "This is a placeholder for names"))
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

        return users;
    }
}
