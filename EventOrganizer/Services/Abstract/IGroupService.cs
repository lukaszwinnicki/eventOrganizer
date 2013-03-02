using System.Collections.Generic;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.Services.Abstract
{
    public interface IGroupService
    {
        IList<Group> GetGropus(string email);
        Group Save(Group @group, string email);
        Group GetGropu(int id);
    }
}