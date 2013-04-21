using System.Collections.Generic;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.DAL.Abstract
{
    public interface IEventRepository
    {
        IList<Event> GetEvents(long groupId);
        long Save(Event eventToSave);
        bool Update(int id, Event eventToUpdate);
        Event GetById(int eventId);
        IList<Event> GetAll();
        void UpdatePhoto(int id, string photoUrl);
    }
}