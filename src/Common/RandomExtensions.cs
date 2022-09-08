// Copyright � BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System;
using Throw;

namespace BenjaminAbt.MyDemoPlatform.Common;

public static class RandomExtensions
{
    public static double GenerateDouble(this Random random, double minValue, double maxValue)
    {
        minValue.Throw($"{nameof(minValue)} cannot be greater than {nameof(maxValue)}").IfGreaterThan(maxValue);
        return minValue + (random.NextDouble() * (maxValue - minValue));
    }
}
