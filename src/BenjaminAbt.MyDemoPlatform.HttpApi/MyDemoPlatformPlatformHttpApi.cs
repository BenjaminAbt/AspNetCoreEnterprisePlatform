using BenjaminAbt.MyDemoPlatform.AspNetCore.Process;

namespace BenjaminAbt.MyDemoPlatform.HttpApi;

public static class MyDemoPlatformPlatformHttpApi
{
    public static int Main(string[] args)
        => Bootstrapper
        .Create<MyDemoPlatformPlatformStartup>(nameof(MyDemoPlatformPlatformHttpApi), args);


}
