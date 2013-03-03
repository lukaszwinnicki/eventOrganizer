using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventOrganizer.Web.Controllers
{
    public class GroupMembersController : ApiController
    {
        public HttpResponseMessage Get(int id)
        {
            return string.IsNullOrEmpty(User.Identity.Name)
                       ? Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.")
                       : Request.CreateResponse(HttpStatusCode.OK, new List<Member>
                           {
                               new Member
                                   {
                                       Name = "Name",
                                       Surname = "Surname",
                                       PhotoUrl = "/Content/Images/holder.png"
                                   }
                           });
        }
    }

    public class Member
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoUrl { get; set; }
    }
}