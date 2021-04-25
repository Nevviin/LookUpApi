using LookUp.Api.CustomException;
using LookUp.Api.Models;
using LookUp.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace LookUp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IListingService _listingService;
        public ListingController(ILogger<ListingController> logger,
            IListingService listingService)
        {
            _logger = logger;
            _listingService = listingService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Listing>>> GetCity([FromQuery][Required] int passengerCount)
        {
           var response =  await _listingService.GetAllListings();
            var sortedResults = _listingService.GetListingByPrice(passengerCount, response.Listings);
            if (sortedResults.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, $"No matching listing for {passengerCount} passengers");
            return Ok(sortedResults);
        }


    }
}
