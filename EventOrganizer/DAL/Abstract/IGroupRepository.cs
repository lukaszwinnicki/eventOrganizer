using System.Collections.Generic;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.DAL.Abstract
{
    public interface IGroupRepository
    {
        IList<Group> GetGroup(long userId);
        Group GetById(long groupId);
        long Save(Group groupToSave);
    }
}