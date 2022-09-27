using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using firstfunction.Models;

namespace MCT.Function
{
    public static class Calculator
    {
        [FunctionName("Calculator")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "calculator")] HttpRequest req,
            ILogger log)
        {

            // CalculationResult result = new CalculationResult();

            // if (operatorr == "+"){
            //     result.Operator = operatorr;
            //     result.Result = getal1 + getal2;

            //     return new OkObjectResult(result);
            // } 
            // // if (operatorr == "+") return new OkObjectResult(getal1 + getal2); //efficienter

            // if (operatorr == "-"){
            //     result.Operator = operatorr;
            //     result.Result = getal1 - getal2;

            //     return new OkObjectResult(result);
            // }

            // if (operatorr == "*")
            // {
            //     result.Operator = operatorr;
            //     result.Result = getal1 * getal2;

            //     return new OkObjectResult(result);
            // }

            // if (operatorr == ":")
            // {
            //     result.Operator = operatorr;
            //     result.Result = getal1 / getal2;

            //     return new OkObjectResult(result);
            // }

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            CalculationRequest data = JsonConvert.DeserializeObject<CalculationRequest>(requestBody);

            CalculationResult result = new CalculationResult();
            result.Result = data.Getal1 + data.Getal2;
            result.Operator = data.Operator;

            return new BadRequestObjectResult(result);
        }
    }
}
