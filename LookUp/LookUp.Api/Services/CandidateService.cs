using LookUp.Api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookUp.Api.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        public CandidateService(IConfiguration configuration, ILogger<CandidateService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }



        /// <summary>
        /// Get the default Candidate from configuration 
        /// </summary>
        /// <returns>Candidate object </returns>
        public Candidate GetDefaultCandidate()
        {
            try {
                var defaultCandidate = new Candidate();
                _configuration.GetSection("DefaultCandidate").Bind(defaultCandidate);
                return defaultCandidate;
            }
            catch (Exception ex)
            {
              _logger.LogError($"Exception in CandidateService.GetDefaultCandidate : {ex.InnerException}");
                throw;
            }
        }
    }
}
