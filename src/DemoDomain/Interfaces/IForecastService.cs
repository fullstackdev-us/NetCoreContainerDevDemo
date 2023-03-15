using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoDomain.Responses;

namespace DemoDomain.Interfaces
{
    public interface IForecastService
    {
        public Task<ForecastAddedResponse> AddForecast(int cityId, int temperatureF);
        public Task<object[]?> ListForecasts();
  }
}