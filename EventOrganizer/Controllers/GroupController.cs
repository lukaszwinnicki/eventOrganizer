using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventOrganizer.Controllers
{
    public class GroupController : ApiController
    {
         public HttpResponseMessage Get()
         {
             // GetLoggedUserUser
             return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.");
         }
    }
}