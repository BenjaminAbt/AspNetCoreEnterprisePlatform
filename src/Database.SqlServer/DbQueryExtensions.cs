// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BenjaminAbt.MyDemoPlatform.Database.SqlServer;

public static class DbQueryExtensions
{
    public static IQueryable<T> With<T>(this IQueryable<T> set,
        DbTrackingOptions trackingOptions) where T : class
    {
        if (trackingOptions == DbTrackingOptions.Disabled)
        {
            set = set.AsNoTracking();
        }

        return set;
    }
}
