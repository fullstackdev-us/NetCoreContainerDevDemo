using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDomain.Interfaces
{
    public interface IForecastService
    {
        public Task AddForecast(int cityId, int temperatureF);
    }
}