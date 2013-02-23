using System.Collections.Generic;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.DAL.Abstract
{
    public interface IGroupRepository : IRepository<Group>
    {
        void AddGroup(Group group);
        IList<Group> GetGroups(long userId);
    }
}