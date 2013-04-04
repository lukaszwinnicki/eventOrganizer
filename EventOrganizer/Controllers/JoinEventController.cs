using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class JoinEventController : ApiController
    {
        private readonly IUserService _userService;

        public JoinEventController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public HttpResponseMessage Post(JoinEvent joinEvent)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.");
            }

            var user = _userService.GetUserByEmail(User.Identity.Name);

            _userService.AddEventMember(user.Id, joinEvent.EventId);

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
    }

    public class JoinEvent
    {
        public long EventId { get; set; }
    }
}