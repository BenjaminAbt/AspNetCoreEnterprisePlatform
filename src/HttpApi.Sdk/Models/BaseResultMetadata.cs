// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;

namespace BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

public abstract class BaseResultMetadata
{
    public BaseResultMetadata(DateTimeOffset on)
    {
        On = on;
    }

    public DateTimeOffset On { get; }
}
