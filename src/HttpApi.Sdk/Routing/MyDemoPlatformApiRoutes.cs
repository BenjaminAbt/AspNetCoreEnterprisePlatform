// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

namespace BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Routing;

public static class MyDemoPlatformApiRoutes
{
    public const string ApiRoot = "";

    public static class Tenants
    {
        public const string TenantsWidget = $"{ApiRoot}/tenants";

        public const string TenantIdQueryParam = "{tenantId}";

        public static class Users
        {
            public const string UsersWidget = $"{TenantsWidget}/{TenantIdQueryParam}/users";
            public const string Add = $"{UsersWidget}";
            public const string List = $"{UsersWidget}";
        }
    }
}
