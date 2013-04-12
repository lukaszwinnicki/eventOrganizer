using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class RegisterUserController : ApiController
    {
        private readonly IUserService _userService;

        public RegisterUserController(IUserService userService)
        {
            _userService = userService;
        }

        public HttpResponseMessage Put(User user)
        {
            _userService.Save(user);

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
    }
}