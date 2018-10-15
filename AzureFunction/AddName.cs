using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;

namespace Company.FunctionApp
{
    public static class AddName
    {
        [FunctionName("AddName")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post")]     
            HttpRequestMessage req,
            TraceWriter log)
        {
            dynamic data = await req.Content.ReadAsAsync<object>();
            string name = data?.name;

            // await names.AddAsync(name);
            return req.CreateResponse(HttpStatusCode.OK, $"{name} added");
        }
    }
}