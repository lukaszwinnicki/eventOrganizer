using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class EventCommentsController : ApiController
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;

        public EventCommentsController(ICommentService commentService, IUserService userService)
        {
            _commentService = commentService;
            _userService = userService;
        }

        [HttpPost]
        public HttpResponseMessage Post(Comment comment)
        {
            // TODO: performance
            if (!User.Identity.IsAuthenticated)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.");
            }

            comment.Member = _userService.GetUserByEmail(User.Identity.Name);
            comment.Id = _commentService.Save(comment);

            return Request.CreateResponse(HttpStatusCode.OK, comment);
        }

        public HttpResponseMessage Get(int id)
        {
            return string.IsNullOrEmpty(User.Identity.Name)
                       ? Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.")
                       : Request.CreateResponse(HttpStatusCode.OK, _commentService.GetEventComments(id));
        }
    }
}