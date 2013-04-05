using System.Collections.Generic;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.Services.Abstract
{
    public interface IUserService
    {
        void Save(User user);
        bool CanAuthorize(string email, string password);
        bool IsEmailAvailable(string email);
        User GetUserByEmail(string email);
        User GetUser(long id);
        bool Update(User member);
        List<EventMember> GetEventMembers(int eventId);
        bool AddEventMember(long userId, long eventId);
        bool RemoveEventMember(long userId, long eventId);
    }
}