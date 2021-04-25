using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Schema;
using System;
using System.Net;

namespace LookUp.Api.Services
{
    /// <summary>
    /// Common helper service 
    /// </summary>
    public class HelperService : IHelperService
    {

        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        public HelperService(IConfiguration configuration, ILogger<HelperService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public string GetLocationUrl(string ipAddress)
        {
            try
            {
                var baseUrl = _configuration.GetSection("LocationApi").GetSection("BaseUrl").Value;
                var endpoint = _configuration.GetSection("LocationApi").GetSection("Endpoint").Value;
                var locationUrl = string.Format(string.Concat(baseUrl, endpoint), ipAddress);
                return locationUrl;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in HelperService.GetLocationUrl : {ex.InnerException}");
                throw;
            }
        }

        public bool IsValidJson(string jsonString)
        {
            try
            {
                var schema = JSchema.Parse(jsonString);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in HelperService.IsValidJson : {ex.InnerException} for jsonResponse :{jsonString} ");
                return false;
            }
        }


        public bool IsValidIp(string ipAddress)
        {
            try
            {
                if (!ipAddress.Contains('.'))
                {
                    return false;
                }

                if (IPAddress.TryParse(ipAddress, out IPAddress address))
                {
                    switch (address.AddressFamily)
                    {
                        case System.Net.Sockets.AddressFamily.InterNetwork:
                            return true;
                        case System.Net.Sockets.AddressFamily.InterNetworkV6:
                            return true;
                        default:
                            return false;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in HelperService.GetLocationUrl : {ex.InnerException}");
                return false;
            }
        }
    }
}
