using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DemoDomain.Interfaces;
using DemoDomain.Payloads;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForecastController : Controller
    {
        private readonly ILogger<ForecastController> logger;
        private readonly IForecastService forecastService;

        public ForecastController(ILogger<ForecastController> logger,
        IForecastService forecastService)
        {
            this.logger = logger;
            this.forecastService = forecastService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddForecastPayload payload)
        {
            var result = await this.forecastService.AddForecast(payload.CityId, payload.TemperatureF);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> List() {
            return Ok(await this.forecastService.ListForecasts());
        }
    }
}