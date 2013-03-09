using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class GroupMembersController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IGroupService _groupService;

        public GroupMembersController(IUserService userService, IGroupService groupService)
        {
            _userService = userService;
            _groupService = groupService;
        }

        public HttpResponseMessage Get(int id)
        {
            return string.IsNullOrEmpty(User.Identity.Name)
                       ? Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.")
                       : Request.CreateResponse(HttpStatusCode.OK, new List<User>
                           {
                               new User
                                   {
                                       Name = "Name",
                                       Surname = "Surname",
                                       PhotoUrl = "/Content/Images/holder.png"
                                   }
                           });
        }

        public HttpResponseMessage JoinGroup(User member, int groupId)
        {
            Group group = _groupService.GetGropu(groupId);
            member.Groups.Add(group);
            return string.IsNullOrEmpty(User.Identity.Name)
                       ? Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.")
                       : Request.CreateResponse(HttpStatusCode.OK, _userService.Update(member));
        }
    }
}