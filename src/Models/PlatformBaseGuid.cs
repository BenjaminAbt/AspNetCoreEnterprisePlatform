// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;

namespace BenjaminAbt.MyDemoPlatform.Models;

public abstract class PlatformBaseGuid
{
    public PlatformBaseGuid() { }
    public PlatformBaseGuid(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; set; }

    public string Format(string format) => Value.ToString(format);

    protected bool Equals(PlatformBaseGuid other) => Value.Equals(other.Value);

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((PlatformBaseGuid)obj);
    }

    public override int GetHashCode() => Value.GetHashCode();


    public override string ToString() => Value.ToString();

    public string ToString(string format) => Value.ToString(format);
}
