using BroData.API;
using BroData.API.Models.v0;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net.Http;
using Xunit;

namespace XUnitTestBroDataApi
{
    public class UnitTest_Telephon
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public UnitTest_Telephon()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        [Fact]
        public async System.Threading.Tasks.Task Test1Async__GetAll()
        {
            HttpResponseMessage response = await _client.GetAsync("/v0.1/GenTelephon");
            response.EnsureSuccessStatusCode();

            string responseString = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<Response<Telephon>>(responseString);
            // Assert
            Assert.IsType<Response<Telephon>>(model);
        }
    }
}
