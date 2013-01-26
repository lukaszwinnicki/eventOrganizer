using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventOrganizer.Web.Controllers
{
    public class GroupController : ApiController
    {
         public HttpResponseMessage Get()
         {
             if (string.IsNullOrEmpty(User.Identity.Name))
             {
                 return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.");
             }
             

         }
    }
}