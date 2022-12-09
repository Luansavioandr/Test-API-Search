using Microsoft.AspNetCore.Mvc;
using Test_API_Search.Business;

namespace Test_API_Search.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        [HttpGet(Name = "GetWeatherForecast")]
        public void Get(string text)
        {
            new SearchBusiness().SearchRequest(text);
           
        }
    }
}