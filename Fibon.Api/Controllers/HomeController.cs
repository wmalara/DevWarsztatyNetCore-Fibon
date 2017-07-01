using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fibon.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return Content("Hello from Fibon API");
        }
    }
}
