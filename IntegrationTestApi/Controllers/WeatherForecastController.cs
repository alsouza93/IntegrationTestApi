﻿using IntegrationTestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationTestApi.Controllers
{
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        public WeatherForecastController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("/report")]
        public ContentResult GetWeatherReport()
        {
            return new ContentResult()
            {
                Content = _weatherService.WriteWeatherReport(),
                StatusCode = 200
            };
        }
    }
}