using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.DAL.Abstract
{
    public interface ISearchRepository
    {
        SearchResult GetSearchItems(string pattern);
    }
}