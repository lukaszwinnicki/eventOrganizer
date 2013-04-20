using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class JoinGroupController : ApiController
    {
        private readonly IUserService _userService;

        public JoinGroupController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public HttpResponseMessage Post(JoinGroup joinGroup)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.");
            }

            _userService.AddGroupMember(joinGroup.UserId, joinGroup.GroupId);

            return Request.CreateResponse(HttpStatusCode.OK, joinGroup.UserId);
        }
    }

    public class JoinGroup
    {
        public long UserId { get; set; }
        public long GroupId { get; set; }
    }
}