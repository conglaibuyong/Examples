using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace ufop_netcore_demo.Controllers
{
    [Route("Health")]
    public class HealthController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return this.Json(new
            {
                code = 200
            });
        }

    }
}
