using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Resources;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class RegisterController : ApiController
    {
        private readonly IUserService _userService;

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut]
        public HttpResponseMessage Save(RegisteringUser user)
        {
            var userByEmail = _userService.GetUserByEmail(user.Email);

            if (userByEmail == null)
            {
                _userService.Save(new User { Email = user.Email, Password = user.Password });
                FormsAuthentication.SetAuthCookie(user.Email, user.Remember);
                return Request.CreateResponse(HttpStatusCode.OK, new { IsValid = true, Url = "/Home/Groups" });
            }

            return Request.CreateResponse(HttpStatusCode.OK, new { IsValid = false, ErrorMessage = ValidationMessages.EmailExists });
        }

    }
}