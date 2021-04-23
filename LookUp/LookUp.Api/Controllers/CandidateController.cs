using LookUp.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookUp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ILogger _logger;
        public CandidateController(ILogger<CandidateController> logger)
        {
            _logger = logger;
        }

        [Produces("application/json")]
        public ActionResult<Candidate> GetCandidate()
        {
            //_logger.LogInformation("Candidate Get Executeing");
            return Ok(new Candidate { Name = "test", Phone = "test" });
            
        }

    }
}
