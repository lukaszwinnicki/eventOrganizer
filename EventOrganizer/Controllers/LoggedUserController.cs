using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class LoggedUserController : ApiController
    {
        private readonly IUserService _userService;

        public LoggedUserController(IUserService userService)
        {
            _userService = userService;
        }

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _userService.GetUserByEmail(User.Identity.Name));
        }

        [HttpDelete]
        public HttpResponseMessage Delete(User user)
        {
            FormsAuthentication.SignOut();

            return Request.CreateResponse(HttpStatusCode.OK, true);
        }
    }
}