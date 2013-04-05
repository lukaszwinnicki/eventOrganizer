using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class LeaveEventController : ApiController
    {
        private readonly IUserService _userService;

        public LeaveEventController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public HttpResponseMessage Post(LeaveEvent leaveEvent)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.");
            }

            return _userService.RemoveEventMember(leaveEvent.User.Id, leaveEvent.EventId)
                       ? Request.CreateResponse(HttpStatusCode.OK, new EventMember(leaveEvent.User))
                       : Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Something went wrong");
        }
    }
}