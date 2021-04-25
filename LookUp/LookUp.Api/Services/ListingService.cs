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
    public class ListingService : IListingService
    {

        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHelperService _helperService;
        public ListingService(IConfiguration configuration,
            ILogger<ListingService> logger
            , IHttpClientFactory httpClientFactory,
            IHelperService helperService
            )
        {
            _configuration = configuration;
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _helperService = helperService;
        }

        public async Task<ListingDetails> GetAllListings()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var listingUrl = _configuration.GetSection("ListingApi").GetSection("Url").Value;
            try
            {
                var response = await httpClient.GetAsync(listingUrl);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var isValidResponse = _helperService.IsValidJson(responseBody);
                if (!isValidResponse) throw new Exception("No location result found for this Ip");
                var listingDetails = JsonConvert.DeserializeObject<ListingDetails>(responseBody);
                return listingDetails;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in ListingService.GetAllListing : {ex.InnerException}");
                throw;
            }
        }

        public List<Listing> GetListingByPrice(int passengers, List<Listing> listings)
        {
            try
            {
                var listingsOrderByPrice = listings
                                   .Where(x => x.VehicleType.MaxPassengers >= passengers)
                                   .OrderBy(x => x.PricePerPassenger * passengers).ToList();

                return listingsOrderByPrice;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in ListingService.GetListingByPrice : {ex.InnerException}");
                throw;
            }
}
    }
}
