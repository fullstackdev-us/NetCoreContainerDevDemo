

using DemoDomain.Interfaces;

namespace DemoDomain.Messages;

public class CityAdded : IMessage
{
  public string City { get; set; }
}
