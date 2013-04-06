using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class SearchController : ApiController
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public HttpResponseMessage Get(string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Search string should not be empty");
            if (pattern.Length < 2)
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                                                   "Search string should have more than 2 characters");
            var model = _searchService.GetSearchItems(pattern);

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
    }
}
