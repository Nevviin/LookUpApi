using LookUp.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookUp.Api.Services
{
    public interface ILocationService
    {
        public Task<LocationDetails> FetchLocation(string ipAddress);
    }
}
