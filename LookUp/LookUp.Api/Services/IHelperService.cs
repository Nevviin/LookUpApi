using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookUp.Api.Services
{
   public interface IHelperService
    {

        public string GetLocationUrl(string ipAddress);

        public bool IsValidJson(string jsonString);

        public bool IsValidIp(string ipAddress);
    }
}
