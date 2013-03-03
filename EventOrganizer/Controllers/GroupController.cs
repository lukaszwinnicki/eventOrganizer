using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class GroupController : ApiController
    {
        private readonly IGroupService _groupService;

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
            return !User.Identity.IsAuthenticated ?
                Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.") :
                Request.CreateResponse(HttpStatusCode.OK, _groupService.Save(group, User.Identity.Name));
        }
    }
}