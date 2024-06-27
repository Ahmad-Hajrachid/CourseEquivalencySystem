using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseEquivalencySite.Models;
using CourseEquivalencySite.Services;
using CourseEquivalencySite.Interfaces;
using Microsoft.Extensions.Logging;

namespace CourseEquivalenctApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseSimilarityController : ControllerBase
    {
        private readonly ICourseSimilarityService _courseSimilarityService;
        private readonly ILogger<CourseSimilarityController> _logger;

        public CourseSimilarityController(ICourseSimilarityService courseSimilarityService, ILogger<CourseSimilarityController> logger)
        {
            _courseSimilarityService = courseSimilarityService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseSimilarityResult>>> GetCourseSimilaritiesAsync()
        {
            try
            {
                _logger.LogInformation("Received request to get course similarities.");
                var result = await _courseSimilarityService.GetCourseSimilaritiesAsync();
                _logger.LogInformation("Successfully retrieved course similarities.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
