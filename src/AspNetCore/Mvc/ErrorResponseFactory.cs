// Copyright � BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;
using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.MyDemoPlatform.AspNetCore.Mvc;

public static class ErrorResponseFactory
{
    public static BadRequestObjectResult BadRequest(string[] errors)
        => new(new ServerErrorBadRequestResponseModel(errors));
}
