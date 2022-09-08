// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using BenjaminAbt.MyDemoPlatform.Engine.Abstractions;
using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Engine.Commands;

public record class TenantUserAddCommand(
     PlatformTenantId PlatformTenantId,
     string Name) : ICommand<PlatformUserId>;
