using IntegrationTestApi.Infrastructure;

namespace IntegrationTestApi.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository weatherRepository;
        public WeatherService(IWeatherRepository weatherRepository)
        {
            this.weatherRepository = weatherRepository;
        }
        public string WriteWeatherReport()
        {
            var weather = weatherRepository.GetWeather();
            return $"Today the  weather is {weather.Summary}. With temperature {weather.TemperatureF}";
        }
    }
}