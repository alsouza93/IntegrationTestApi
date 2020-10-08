using IntegrationTestApi;
using IntegrationTestApi.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace IntegrationTest
{
    public class ReportTest
    {
        [Fact]
        public void TestReportWithRamdonForecast()
        {
            //Arrange
            var hostBuilder = new HostBuilder()
                    .ConfigureWebHost(webHost =>
                    {
                        webHost.UseTestServer();
                        webHost.UseEnvironment("Test");
                        webHost.UseStartup<Startup>();
                    });

            var host = hostBuilder.Start();
            var client = host.GetTestClient();

            // Act
            var response = client.GetAsync("/report");
            var responseString = response.Result.Content.ReadAsStringAsync();

            // Assert
            Assert.NotNull(responseString.Result);
        }


        [Fact]
        public void TestReportWithFixForecast()
        {
            //Arrange
            var hostBuilder = new HostBuilder()
                 .ConfigureWebHost(webHost =>
                 {
                     webHost.UseTestServer();
                     webHost.UseEnvironment("Test");
                     webHost.UseStartup<Startup>();
                     webHost.ConfigureTestServices(services =>
                     {
                         services.SwapTransient<IWeatherRepository, FakeWeatherRepository>();
                     });
                 });

            var host = hostBuilder.Start();
            var client = host.GetTestClient();

            // Act
            var response = client.GetAsync("/report");
            var responseString = response.Result.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("Today's weather is Warm. With temperature 73", responseString.Result);
        }

    }
}
