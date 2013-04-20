using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _userService.GetUsers());
        }

        public HttpResponseMessage Get(string pattern)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _userService.GetUsers(pattern));
        }
    }
}