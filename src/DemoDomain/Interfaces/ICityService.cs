using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDomain.Interfaces
{
    public interface ICityService
    {
        public Task AddCity(string name);
    }
}