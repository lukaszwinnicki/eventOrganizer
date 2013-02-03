using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class GroupController : ApiController
    {
        private readonly IGroupService _groupService;

        public GroupController()
            : this(new GroupService())
        {

        }

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public HttpResponseMessage Get(int id)
        {
            return string.IsNullOrEmpty(User.Identity.Name) ?
                Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.") :
                Request.CreateResponse(HttpStatusCode.OK, _groupService.GetGropu(id));
        }

        public HttpResponseMessage Post(Group group)
        {
            var newGroup = _groupService.Save(group);

            return Request.CreateResponse(HttpStatusCode.OK, newGroup);
        }
    }
}