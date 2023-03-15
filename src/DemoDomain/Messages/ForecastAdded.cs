using DemoDomain.Interfaces;

namespace DemoDomain.Messages;

public class ForecastAdded : IMessage
{
  public string CityName { get; set; }
  public int CityId { get; set; }
  public int TemperatureF { get; set; }
}
