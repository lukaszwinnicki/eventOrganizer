using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class GroupsController : ApiController
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public HttpResponseMessage Get()
        {
            return string.IsNullOrEmpty(User.Identity.Name) ?
                Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.") :
                Request.CreateResponse(HttpStatusCode.OK, _groupService.GetGropus(User.Identity.Name));
        }
    }
}