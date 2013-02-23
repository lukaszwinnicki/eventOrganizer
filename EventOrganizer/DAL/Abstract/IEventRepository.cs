using System.Collections.Generic;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.DAL.Abstract
{
    public interface IEventRepository : IRepository<Event>
    {
        IList<Event> GetEvents(long groupId);
    }
}