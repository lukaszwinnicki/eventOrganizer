using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using ServiceStack.Redis;

namespace EventOrganizer.Web.DAL
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(IRedisClient client) : base(client)
        {
        }

        public override long Add(Event @event)
        {
            var id = base.Add(@event);
            Client.Lists["group-events-" + @event.GroupId].Add(id.ToString(CultureInfo.InvariantCulture));

            return id;
        }

        public IList<Event> GetEvents(long groupId)
        {
            var events = Client.Lists["group-events-" + groupId];

            return events.GetAll().Select(x => GetById(long.Parse(x))).ToList();
        }
    }
}