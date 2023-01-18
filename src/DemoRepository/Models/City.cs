namespace DemoRepository.Models;
public class City
{
  public int Id { get; set; }
  public string Name { get; set; }

  public virtual ICollection<Forecast> Forecasts { get; set; }
}
