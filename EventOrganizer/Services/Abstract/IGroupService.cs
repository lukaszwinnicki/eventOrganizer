using System.Collections.Generic;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.Services.Abstract
{
    public interface IGroupService
    {
        IList<Group> GetGropus(string userId);
        Group Save(Group group);
    }
}