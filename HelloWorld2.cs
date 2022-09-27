using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MCT.Function
{
    public static class HelloWorld2
    {
        [FunctionName("HelloWorld2")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "hello/world/welcome")] HttpRequest req,
            ILogger log)
        {
            try
            {
                var name = "HelloWorld";
                return new OkObjectResult(name);  
            }
            catch (System.Exception)
            {
                // return new StatusCodeResult(StatusCodes.Status500InternalServerError); // om een 500 terug te krijgen
                return new BadRequestObjectResult("Something went wrong");                 // 400 terug krijgen
            }
            
        }
    }
}
