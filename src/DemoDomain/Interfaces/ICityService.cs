using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoDomain.Responses;

namespace DemoDomain.Interfaces
{
    public interface ICityService
    {
        public Task<CityAddedResponse> AddCity(string name);
        public Task<object[]?> ListCities();
  }
}