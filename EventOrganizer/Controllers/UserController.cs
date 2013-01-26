using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventOrganizer.Web.Services;

namespace EventOrganizer.Web.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        public HttpResponseMessage Get(string id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _userService.GetUser(id));
        }
    }
}