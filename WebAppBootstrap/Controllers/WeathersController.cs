using Microsoft.AspNetCore.Mvc;
using Refit;
using WebAppBootstrap.Weathers;

namespace WebAppBootstrap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public WeathersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeather([FromQuery] double lat, [FromQuery] double lon)
        {
            var weatherApi = RestService.For<IWeatherApi>(_configuration["Weather:Url"]!);
            var result = await weatherApi.GetWeatherAsync(lat, lon, _configuration["Weather:Key"]!);

            return Ok(new GetWeatherResult
            {
                Temperature = result.main.temp
            });
        }

        public class GetWeatherResult
        {
            public double Temperature { get; set; }
        }
    }
}
