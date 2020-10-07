using IntegrationTestApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System;
using Xunit;

namespace IntegrationTest
{
    public class ReportTest
    {
        [Fact]
        public void TestReport()
        {
            //Arrange
            var hostBuilder = new HostBuilder()
                    .ConfigureWebHost(webHost =>
                    {
                        // Add TestServer
                        webHost.UseTestServer();
                        webHost.UseStartup<Startup>();
                    });

            var host = hostBuilder.Start();
            var client = host.GetTestClient();
            // Act
            var response =  client.GetAsync("/report");
            var responseString = response.Result.Content.ReadAsStringAsync();

            // Assert
            Assert.NotNull(responseString);
        }
    }
}
