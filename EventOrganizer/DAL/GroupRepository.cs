using System;
using System.Collections.Generic;
using System.Linq;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using ServiceStack.Redis;

namespace EventOrganizer.Web.DAL
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(IRedisClient client)
            : base(client)
        {
        }

        public void AddGroup(Group group)
        {
            using (var groups = Client.As<Group>())
            {
                var id = groups.GetNextSequence();
                group.Id = id;
                groups.Store(group);

                Client.Lists["group-users-" + id].Add(group.CreatorId.ToString());
                Client.Lists["user-groups-" + group.CreatorId].Add(id.ToString());
            }
        }

        public IList<Group> GetGroups(long userId)
        {
            var groupsIds = Client.Lists["user-groups-" + userId];
            return groupsIds.GetAll().Select(x => GetById(long.Parse(x))).ToList();
        }
    }
}