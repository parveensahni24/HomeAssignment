using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoneylionHomeTest.Business.Entities;
using MoneylionHomeTest.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneylionHomeTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    [Produces("application/json")]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureUsageRepository _featureUsageRepository;
        private readonly ILogger _logger;

        public FeatureController(IFeatureUsageRepository featureUsageRepository,ILogger<FeatureController> logger)
        {
            _featureUsageRepository = featureUsageRepository;
            _logger = logger;
        }

        
        [HttpGet]
        public IActionResult Get(string email,string featureName)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return BadRequest("Please provide valid email.");
            }

            if (string.IsNullOrWhiteSpace(featureName))
            {
                return BadRequest("Please provide valid feature name.");
            }
            try
            {
                FeatureUsage featureUsage= _featureUsageRepository.GetByEmailAndFeature(email, featureName);

                dynamic row = new ExpandoObject();

                if (featureUsage != null)
                {
                    row.canAccess= featureUsage.Enable;
                }
                else
                {
                    return NotFound();
                }
                                
                return new JsonResult(row);
            }

            catch (Exception ex)
            {
                _logger.LogError($"FeatureController Get Method Exception {0}", ex.Message);
                return StatusCode(500);
            }
            
        }

        [HttpPost]
        public IActionResult Create(FeatureUsage featureUsage)
        {
            try
            {
                _featureUsageRepository.AddFeatureUsage(featureUsage);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"FeatureController Create Method Exception {0}", ex.Message);
                return StatusCode(304);
            }

            
        }


    }
}
