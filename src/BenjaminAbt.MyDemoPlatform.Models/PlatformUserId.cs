using System;

namespace BenjaminAbt.MyDemoPlatform.Models;

public sealed class PlatformUserId : PlatformBaseGuid
{
    public PlatformUserId() : base() { }
    public PlatformUserId(Guid value) : base(value) { }
}
