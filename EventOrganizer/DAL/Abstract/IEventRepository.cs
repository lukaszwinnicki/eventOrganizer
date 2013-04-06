using System.Collections.Generic;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.DAL.Abstract
{
    public interface IEventRepository
    {
        IList<Event> GetEvents(long groupId);
        long Save(Event eventToSave);
        Event GetById(int eventId);
        IList<Event> GetAll();
        void UpdatePhoto(int id, string photoUrl);
    }
}