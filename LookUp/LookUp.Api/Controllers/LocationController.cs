﻿using LookUp.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System;

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
            var isValidIp = IPAddress.TryParse(ipAddress, out IPAddress ip);
            if(!isValidIp) throw new Exception("Invalid Ip Address");
            var locationDetails = await _locationService.FetchLocation(ipAddress);
            return locationDetails.City;
        }
    }
}
