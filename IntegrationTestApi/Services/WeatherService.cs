using IntegrationTestApi.Infrastructure;

namespace IntegrationTestApi.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;
        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }
        public string WriteWeatherForecastReport()
        {
            var weather = _weatherRepository.GetWeatherForecast();
            return $"Today's weather is {weather.Summary}. With temperature {weather.TemperatureF}";
        }
    }
}