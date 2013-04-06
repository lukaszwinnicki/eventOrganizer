using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.Services.Abstract
{
    public interface ISearchService
    {
        SearchResult GetSearchItems(string pattern);
    }
}