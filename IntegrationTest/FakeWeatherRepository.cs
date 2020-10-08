using IntegrationTestApi;
using IntegrationTestApi.Infrastructure;
using System;

namespace IntegrationTest
{
    public class FakeWeatherRepository : IWeatherRepository
    {
        public WeatherForecast GetWeatherForecast()
        {           
            return new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = 23,
                Summary = "Warm"
            };
        }
    }
}