using Microsoft.AspNetCore.Mvc;

namespace LinkConnCounterWithRapidAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("GetWeather")]
        public async Task<IActionResult> GetWeatherForecast(double latitude, double longitude)
        {
            var weatherForecast = await _weatherService.GetWeatherForecast(latitude, longitude);

            return Ok(weatherForecast);
        }
    }
}
