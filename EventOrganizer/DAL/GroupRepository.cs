using System;
using System.Collections.Generic;
using System.Globalization;
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

        public IList<Group> GetGroups(long userId)
        {
            var groupsIds = Client.Lists["user-groups-" + userId];
            return groupsIds.GetAll().Select(x => GetById(long.Parse(x))).ToList();
        }

        public override long Add(Group @group)
        {
            var id = base.Add(group);
            Client.Lists["group-users-" + id].Add(@group.CreatorId.ToString(CultureInfo.InvariantCulture));
            Client.Lists["user-groups-" + @group.CreatorId].Add(id.ToString(CultureInfo.InvariantCulture));
            return id;
        }
    }
}