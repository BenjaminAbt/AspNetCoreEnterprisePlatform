using System;

namespace BenjaminAbt.MyDemoPlatform.Models;

public sealed class PlatformTenantId : PlatformBaseGuid
{
    public PlatformTenantId() : base() { }
    public PlatformTenantId(Guid value) : base(value) { }
}
