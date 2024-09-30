using CodingAssignment.src.Models;
using CodingAssignment.src.Models.GetBikeThefts;
using CodingAssignment.src.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CodingAssignment.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _bikeTheftService;

        public SearchController(ISearchService bikeTheftService)
        {
            _bikeTheftService = bikeTheftService;
        }

        [HttpGet]
        [Route("count")]
        [ProducesResponseType(typeof(SearchCountResponse), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> SearchCount([FromQuery] SearchParams searchParams)
        {
            // location is provided if stolenness is 'proximity'
            if (searchParams.Stolenness == Stolenness.proximity && string.IsNullOrWhiteSpace(searchParams.Location))
            {
                return BadRequest("A valid location must be provided when stolenness is 'proximity'.");
            }

            var result = await _bikeTheftService.SearchCount(searchParams);
            return Ok(result);
        }
    }
}
