using BenjaminAbt.MyDemoPlatform.Models;

namespace BenjaminAbt.MyDemoPlatform.Features.Tenants.Models;

public readonly record struct UserInfoModel(PlatformUserId Id, string Name);
