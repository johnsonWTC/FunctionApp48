using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp48
{
    public  class Function1
    {
        private readonly ICrud _crud;
        Function1(ICrud crud)
        {
            _crud = crud;
        }

        [FunctionName("Function1")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            User data = JsonConvert.DeserializeObject<User>(requestBody);
            string responseMessage = "";

            return new OkObjectResult(responseMessage);
        }
    }
}
