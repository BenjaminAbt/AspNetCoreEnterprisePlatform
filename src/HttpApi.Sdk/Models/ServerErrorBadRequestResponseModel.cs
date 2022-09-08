// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using System.Collections.Generic;
using System.Linq;

namespace BenjaminAbt.MyDemoPlatform.HttpApi.Sdk.Models;

public class ServerErrorBadRequestResponseModel : ServerErrorBaseModel
{
    public ServerErrorBadRequestResponseModel()
    {
        Errors = Enumerable.Empty<string>();
    }

    public ServerErrorBadRequestResponseModel(IEnumerable<string> errors)
    {
        Errors = errors;
    }

    public IEnumerable<string> Errors { get; set; } = null!;
}
