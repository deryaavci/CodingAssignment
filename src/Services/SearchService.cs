using CodingAssignment.src.Models;
using CodingAssignment.src.Models.GetBikeThefts;

namespace CodingAssignment.src.Services
{
    public class SearchService: ISearchService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SearchService(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _baseApiUrl = configuration["BikeIndexApi:BaseUrl"];
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> SearchCount(SearchParams searchParams)
        {
            var queryParams = BuildQueryParams(searchParams);

            string apiUrl = $"{_baseApiUrl}/search/count?" + string.Join("&", queryParams);

            var result = await _httpClient.GetStringAsync(apiUrl);
            return result;
        }

        private List<string> BuildQueryParams(SearchParams searchParams)
        {
            var queryParams = new List<string>
                          {
                              $"page={searchParams.Page}",
                              $"per_page={searchParams.PerPage}",
                              $"stolenness={searchParams.Stolenness.ToString().ToLower()}"
                          };

            if (searchParams.Stolenness == Stolenness.proximity)
            {
                //TODO:On Kubernetes, it may not be possible to directly obtain the client IP address using HttpContextAccessor.
                //The X-Forwarded-For header needs to be configured.
                if (searchParams.Location == "IP")
                {
                    searchParams.Location = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
                }

                queryParams.Add($"location={searchParams.Location}");
                queryParams.Add($"distance={searchParams.Distance}");
            }

            if (!string.IsNullOrWhiteSpace(searchParams.Serial))
                queryParams.Add($"serial={searchParams.Serial}");
            if (!string.IsNullOrWhiteSpace(searchParams.Query))
                queryParams.Add($"query={searchParams.Query}");
            if (!string.IsNullOrWhiteSpace(searchParams.Manufacturer))
                queryParams.Add($"manufacturer={searchParams.Manufacturer}");
            if (!string.IsNullOrWhiteSpace(searchParams.CycleType))
                queryParams.Add($"cycle_type={searchParams.CycleType}");
            if (!string.IsNullOrWhiteSpace(searchParams.PropulsionType))
                queryParams.Add($"propulsion_type={searchParams.PropulsionType}");
            if (!string.IsNullOrWhiteSpace(searchParams.Colors))
                queryParams.Add($"colors={searchParams.Colors}");

            return queryParams;
        }
    }
}
