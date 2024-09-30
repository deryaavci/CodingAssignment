using CodingAssignment.src.Models.GetBikeThefts;

namespace CodingAssignment.src.Services
{
    public interface ISearchService
    {
       public Task<string> SearchCount(SearchParams searchParams);
    }
}
