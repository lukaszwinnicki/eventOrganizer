using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class CommentsController : ApiController
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public HttpResponseMessage Post(Comment comment)
        {
            return !User.Identity.IsAuthenticated ?
                Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.") :
                Request.CreateResponse(HttpStatusCode.OK, _commentService.Save(comment));
        }
    }
}