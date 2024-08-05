using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Company.Function
{
    public static class GetResumeCounter
    {
        [FunctionName("GetResumeCounter")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req,
            [CosmosDB(databaseName:"AzureResume", containerName:"Counter", Connection ="AzureResumeConnectionString", Id = "1", PartitionKey = "1")] Counter counter,
            [CosmosDB(databaseName:"AzureResume", containerName:"Counter", Connection ="AzureResumeConnectionString", Id = "1", PartitionKey = "1")] out Counter updatedCounter
            )
        {
            updatedCounter = counter;
            updatedCounter.Count += 1;

            var JsonToReturn = JsonConvert.SerializeObject(counter);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(JsonToReturn, Encoding.UTF8, "application/json")
             };


        }
    }
}