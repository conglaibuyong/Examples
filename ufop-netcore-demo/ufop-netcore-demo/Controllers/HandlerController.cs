using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.IO;

namespace ufop_netcore_demo.Controllers
{
    [Route("Handler")]
    public class HandlerController : Controller
    {
        [HttpGet]
        public IActionResult Version()
        {
            return this.Json(new
            {
                v = "v15"
            });
        }


        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var cmd = this.Request.Query["cmd"];
            var url = this.Request.Query["url"];

            byte[] fileContents;

            try
            {

                if (url.Any())
                {
                    using (var c = new HttpClient())
                    {
                        fileContents = await c.GetByteArrayAsync(url[0]);
                    }
                }
                else
                {
                    using (var br = new BinaryReader(this.Request.Body))
                    {
                        fileContents = br.ReadBytes(1024 * 1024 * 16);
                    }
                }

                return this.File(fileContents, "image/png");
            }
            catch (Exception ex)
            {
                return this.Json(new
                {
                    cmd = cmd,
                    url = url,
                    ex = ex.ToString()
                });
            }

        }

    }
}
