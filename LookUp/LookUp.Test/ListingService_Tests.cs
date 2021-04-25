using LookUp.Api.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Net.Http;
using Xunit;

namespace LookUp.Test
{
    public class ListingService_Tests
    {
        [Fact]
        public void Test_GetListingByPrice()
        {
           //Arrange
            var httpClient = Mock.Of<IHttpClientFactory>();
            var logger = Mock.Of<ILogger<ListingService>>();
            var helperService = Mock.Of<IHelperService>();
            var configuration  = Mock.Of<IConfiguration>();
            var listingService = new ListingService(configuration, logger, httpClient, helperService);
            var listings = TestHelper.GetListingData();
            
            //Act
            var result = listingService.GetListingByPrice(3, listings);

            //Assert
            Assert.Equal("Listing 2", result[0].Name);
    }
    }
}
