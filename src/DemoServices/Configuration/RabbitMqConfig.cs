using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoServices.Configuration;

public class RabbitMqConfig
{
  public const string SectionName = "RabbitMq";
  public string Host { get; set; }
  public string VirtualHost { get; set; }
  public string Username { get; set; }
  public string Password { get; set; }
}
