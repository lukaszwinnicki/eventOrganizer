using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class EventController : ApiController
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public HttpResponseMessage Get(int id)
        {
            Event groupEvent = _eventService.GetEvent(id);
            groupEvent.Participants = new List<User>
                {
                    new User
                        {
                            Email = "aaa@aa.a",
                            Id = 1,
                            Name = "Name",
                            Password = "Password",
                            PhotoUrl = "/Content/Images/bejdzi.jpg",
                            Surname = "bbb"
                        }
                };
            groupEvent.Comments = new List<Comment>
                {
                    new Comment
                        {
                            Id = 1, 
                            EventId = groupEvent.Id, 
                            Message = "Lalalala", 
                            Member = groupEvent.Participants.First()
                        }
                };

            return string.IsNullOrEmpty(User.Identity.Name)
                       ? Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.")
                       : Request.CreateResponse(HttpStatusCode.OK, groupEvent);
        }
    }
}