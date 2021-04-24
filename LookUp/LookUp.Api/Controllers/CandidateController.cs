using LookUp.Api.Models;
using LookUp.Api.Services;
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
        private readonly ICandidateService _candidateService;
        public CandidateController(ILogger<CandidateController> logger,
            ICandidateService candidateService)
        {
            _logger = logger;
            _candidateService = candidateService;
        }

        [Produces("application/json")]
        public ActionResult<Candidate> GetCandidate()
        {
            var defaultCandidate = _candidateService.GetDefaultCandidate();
            return Ok(defaultCandidate);

        }

    }
}
