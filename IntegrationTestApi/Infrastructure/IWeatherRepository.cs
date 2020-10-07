namespace IntegrationTestApi.Infrastructure
{
    public interface IWeatherRepository
    {
        WeatherForecast GetWeather();
    }
}