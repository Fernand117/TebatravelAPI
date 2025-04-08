using Microsoft.AspNetCore.Mvc;

namespace TebatravelAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult Get()
        {
            return Ok("Bienvenido");
        }
    }
}
