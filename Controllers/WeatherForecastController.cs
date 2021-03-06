using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("0.1")]
    [ApiVersion("1.0")]    
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Postgre _db;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, Postgre db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("Test")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Gender>> TestV1(){
            return await _db.gender.FirstOrDefaultAsync();
        }

        [HttpGet("Test")]
        [MapToApiVersion("0.1")]
        public string TestV01(){
            return "await _db.gender.FirstOrDefaultAsync();";
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
