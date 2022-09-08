// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;

namespace BenjaminAbt.MyDemoPlatform.Models;

public sealed class PlatformUserId : PlatformBaseGuid
{
    public PlatformUserId() : base() { }
    public PlatformUserId(Guid value) : base(value) { }
}
