// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;

namespace BenjaminAbt.MyDemoPlatform.Models;

public sealed class PlatformTenantId : PlatformBaseGuid
{
    public PlatformTenantId() : base() { }
    public PlatformTenantId(Guid value) : base(value) { }
}
