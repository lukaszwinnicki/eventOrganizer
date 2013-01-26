using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventOrganizer.Web.Services;

namespace EventOrganizer.Web.Controllers
{
    public class LoggedUserController : ApiController
    {
        private readonly UserService _userService;

        public LoggedUserController()
        {
            _userService = new UserService();
        }

         public HttpResponseMessage Get()
         {
             return Request.CreateResponse(HttpStatusCode.OK, _userService.GetUserByEmail(User.Identity.Name));
         }
    }
}