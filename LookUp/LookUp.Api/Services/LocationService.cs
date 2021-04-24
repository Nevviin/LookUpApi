using LookUp.Api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
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
        public LocationService(IConfiguration configuration, 
            ILogger<LocationService> logger
            , IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<LocationDetails> FetchLocation(string ipAddress)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var baseUrl = _configuration.GetSection("LocationApi").GetSection("BaseUrl").Value;
            var endpoint = _configuration.GetSection("LocationApi").GetSection("Endpoint").Value;
            var getUrl = string.Format(string.Concat(baseUrl, endpoint), ipAddress);
            var response = await httpClient.GetAsync(getUrl);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            var locationDetails = JsonConvert.DeserializeObject<LocationDetails>(responseBody);
            return locationDetails;
        }
    }
}
