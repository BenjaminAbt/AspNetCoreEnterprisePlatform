// Copyright © BEN ABT (www.benjamin-abt.com) 2021-2022 - all rights reserved

using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.MyDemoPlatform.Features.Todos.AspNetCore;

public class TodoController : Controller

{
    [Route("api/todo")]
    [HttpGet]
    public IActionResult Todo() => Content("Todo");
}
