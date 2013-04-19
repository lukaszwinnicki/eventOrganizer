using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public HttpResponseMessage Get(long id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _userService.GetUser(id));
        }

        public HttpResponseMessage Put(User user)
        {
            if(user.Id > 0)
            {
                _userService.Update(user);
            }
            else
            {
                _userService.Save(user);
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
    }
}