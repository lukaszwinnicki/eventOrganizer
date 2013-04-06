using System.Collections.Generic;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IList<Event> GetEvents(int groupId)
        {
            return _eventRepository.GetEvents(groupId);
        }

        public Event GetEvent(int id)
        {
            return _eventRepository.GetById(id);
        }

        public long Save(Event eventToSave)
        {
            return _eventRepository.Save(eventToSave);
        }

        public void UpdatePhoto(int id, string photoUrl)
        {
            _eventRepository.UpdatePhoto(id, photoUrl);
        }
    }
}