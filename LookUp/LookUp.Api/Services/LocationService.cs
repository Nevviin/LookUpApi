using LookUp.Api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LookUp.Api.Services
{
    public class LocationService : ILocationService
    {

        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHelperService _helperService;
        public LocationService(IConfiguration configuration,
            ILogger<LocationService> logger
            , IHttpClientFactory httpClientFactory,
            IHelperService helperService
            )
        {
            _configuration = configuration;
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _helperService = helperService;
        }
        public async Task<LocationDetails> FetchLocation(string ipAddress)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var locationUrl = _helperService.GetLocationUrl(ipAddress);
            try
            {
                var response = await httpClient.GetAsync(locationUrl);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                //var isValidResponse = _helperService.IsValidJson(responseBody);
                //if (!isValidResponse) throw new Exception("No location result found for this Ip");
                var locationDetails = JsonConvert.DeserializeObject<LocationDetails>(responseBody);
                return locationDetails;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in LocationService.FetchLocation : {ex.InnerException}");
                throw;
            }
        }
    }
}
