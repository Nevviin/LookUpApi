using LookUp.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LookUp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ILocationService _locationService;
        public LocationController(ILogger<LocationController> logger,
            ILocationService locationService)
        {
            _logger = logger;
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetCity([FromQuery][Required]string ipAddress)
        {
            var locationDetails = await _locationService.FetchLocation(ipAddress);
            return locationDetails.City;
        }
    }
}
