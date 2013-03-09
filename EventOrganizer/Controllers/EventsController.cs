using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Controllers
{
    public class EventsController : ApiController
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public HttpResponseMessage Get(int id)
        {
            return string.IsNullOrEmpty(User.Identity.Name)
                       ? Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.")
                       : Request.CreateResponse(HttpStatusCode.OK, _eventService.GetEvents(id));
        }

        [HttpPost]
        public HttpResponseMessage Put(Event eventToSave)
        {
            eventToSave.Id = _eventService.Save(eventToSave);

            return string.IsNullOrEmpty(User.Identity.Name)
                       ? Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.")
                       : Request.CreateResponse(HttpStatusCode.OK, eventToSave);
        }
    }
}