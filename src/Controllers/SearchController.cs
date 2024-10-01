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
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = _searchService;
        }

        [HttpGet]
        [Route("count")]
        [ProducesResponseType(typeof(SearchCountResponse), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> SearchCount([FromQuery] SearchParams searchParams)
        {
            try
            {
                // location is provided if stolenness is 'proximity'
                if (searchParams.Stolenness == Stolenness.proximity && string.IsNullOrWhiteSpace(searchParams.Location))
                {
                    return BadRequest("A valid location must be provided when stolenness is 'proximity'.");
                }

                var result = await _searchService.SearchCount(searchParams);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //logging
                return StatusCode((int)HttpStatusCode.InternalServerError, "An unexpected error occurred: " + ex.Message);
            }

        }
    }
}
