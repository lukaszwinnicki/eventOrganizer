using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class EventMembersController : ApiController
    {
        private readonly IUserService _userService;

        public EventMembersController(IUserService userService)
        {
            _userService = userService;
        }

        public HttpResponseMessage Get(int id)
        {
            List<EventMember> eventMembers = _userService.GetEventMembers(id);

            return string.IsNullOrEmpty(User.Identity.Name)
                       ? Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.")
                       : Request.CreateResponse(HttpStatusCode.OK, eventMembers);
        }
    }
}