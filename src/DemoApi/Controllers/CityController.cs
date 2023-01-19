using DemoDomain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
  private readonly ILogger<CityController> logger;
  private readonly IMessageService messageService;

  public CityController(
          ILogger<CityController> logger,
          IMessageService messageService
      )
  {
    this.logger = logger;
    this.messageService = messageService;
  }

  [HttpPost]
  public IActionResult Post([FromBody] string message)
  {
    messageService.SendMessage(message);

    return Ok();
  }
}
