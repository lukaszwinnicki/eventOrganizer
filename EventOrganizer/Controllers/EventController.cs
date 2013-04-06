using System.IO;
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

        public static void CopyStream(Stream input, Stream output)
        {
            var buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }

        public HttpResponseMessage Post(Event eventToSave)
        {

            long eventId = _eventService.Save(eventToSave);

            eventToSave.Id = eventId;

            //string userImageDirectory = string.Format("{0}/UserImages/{1}", root, userId);
            //if (!Directory.Exists(userImageDirectory))
            //{
            //    Directory.CreateDirectory(userImageDirectory);
            //}

            //string imagePath = string.Format("{0}/{1}", userImageDirectory, file.FileName);
            //using (FileStream output = System.IO.File.OpenWrite(imagePath))
            //{
            //    CopyStream(file.InputStream, output);
            //}

            //string relativeImagePath = string.Format("/Content/UserImages/{0}/{1}", userId, file.FileName);
            //user.PhotoUrl = relativeImagePath;
            //_userService.Update(user);

            return Request.CreateResponse(HttpStatusCode.OK, eventToSave);
        }

        public HttpResponseMessage Get(int id)
        {
            Event groupEvent = _eventService.GetEvent(id);

            return string.IsNullOrEmpty(User.Identity.Name)
                       ? Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Please log in.")
                       : Request.CreateResponse(HttpStatusCode.OK, groupEvent);
        }
    }
}