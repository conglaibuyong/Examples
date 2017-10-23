using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace ufop_netcore_demo.Controllers
{
    [Route("Handler")]
    public class HandlerController1 : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return this.Json(new
            {
                v = "Get OK v2"
            });
        }


        [HttpPost]
        public IActionResult Post()
        {
            return this.Json(new
            {
                v = "Post OK v2"
            });
        }

    }
}
