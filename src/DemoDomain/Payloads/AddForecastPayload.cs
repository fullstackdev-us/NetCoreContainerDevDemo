using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDomain.Payloads
{
    public class AddForecastPayload
    {
        public int CityId { get; set; }
        public int TemperatureF { get; set; }
    }
}