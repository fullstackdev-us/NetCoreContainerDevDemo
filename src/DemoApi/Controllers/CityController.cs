using DemoDomain.Interfaces;
using DemoDomain.Payloads;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
  private readonly ILogger<CityController> logger;
  private readonly ICityService cityService;

  public CityController(
          ILogger<CityController> logger,
          ICityService cityService
      )
  {
    this.logger = logger;
    this.cityService = cityService;
  }

  [HttpPost]
  public async Task<IActionResult> Post([FromBody] AddCityPayload payload)
  {
    var result = await this.cityService.AddCity(payload.Name);

    return Ok(result);
  }

  [HttpGet]
  public async Task<IActionResult> List() {
    return Ok(await this.cityService.ListCities());
  }
}
