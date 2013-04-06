using System;
using System.Collections.Generic;
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

        public EventCommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public HttpResponseMessage Post(Comment comment)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.");
            }
            comment.UpdatedAt = DateTime.Now;
            comment.Id = _commentService.Save(comment);

            return Request.CreateResponse(HttpStatusCode.OK, comment);
        }

        public HttpResponseMessage Get(int id)
        {
            List<EventComment> eventComments = _commentService.GetEventComments(id);

            return string.IsNullOrEmpty(User.Identity.Name)
                       ? Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.")
                       : Request.CreateResponse(HttpStatusCode.OK, eventComments);
        }
    }
}