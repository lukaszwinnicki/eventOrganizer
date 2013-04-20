using System.Collections.Generic;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.DAL.Abstract
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
        List<GroupMember> GetGroupMembers(long groupId);
        bool Update(User user);
        long Save(User user);
        User GetById(long userId);
        List<User> GetAll();
        List<EventMember> GetEventMembers(int eventId);
        bool AddEventMember(long userId, long eventId);
        bool RemoveEventMember(long userId, long eventId);
        List<User> GetAll(string pattern);
        bool AddGroupMember(long userId, long groupId);
    }
}