using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;

namespace WebApplication.Tests.Controllers
{
    public class HomeController : Controller
    {
        private INodeServices NodeServices;
        public HomeController(INodeServices nodeServices)
        {
            NodeServices = nodeServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Test()
        {
            var result = await NodeServices.InvokeAsync<int>("./Node/addNumbers", 1, 2);
            return Content("1 + 2 = " + result);


            //return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
