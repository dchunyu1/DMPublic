using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewProject.Data;
using InterviewProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InterviewProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GetWeatherInfoController : ControllerBase
    {

        private readonly ILogger<GetWeatherInfoController> _logger;
        public GetWeatherInfoController(ILogger<GetWeatherInfoController> logger)
        {
            _logger = logger;


        }

        [HttpGet]
        public async Task<List<WeatherInfo>> GetAsync(int id)
        {
            var getWeatherInfoByID = new GetWeatherInfoByID();
            List<WeatherInfo> result = await getWeatherInfoByID.GetWeatherAsync(id);
            return result;
        }
    }
}
