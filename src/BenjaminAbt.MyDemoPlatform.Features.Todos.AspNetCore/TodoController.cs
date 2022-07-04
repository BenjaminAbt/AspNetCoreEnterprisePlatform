using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.MyDemoPlatform.Features.Todos.AspNetCore;
public class TodoController:Controller

{
    [Route("api/todo")]
    public IActionResult Todo() => Content("Todo");
}
