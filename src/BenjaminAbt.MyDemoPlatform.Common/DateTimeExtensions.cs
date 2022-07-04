using System;

namespace BenjaminAbt.MyDemoPlatform.Common;

public static class DateTimeExtensions
{
    public static string ToISO8601(this DateTimeOffset source) => source.ToString("o");
}
