using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDomain.Responses
{
    public class ForecastAddedResponse
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int TemperatureF { get; set; }
    }
}