using System.Collections.Generic;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.Services.Abstract
{
    public interface IEventService
    {
        IList<Event> GetEvents(int groupId);
    }
}