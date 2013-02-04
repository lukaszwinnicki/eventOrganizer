using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.Services.Abstract
{
    public interface IUserService
    {
        void AddUser(User user);
        bool CanAuthorize(string email, string password);
        bool IsEmailAvailable(string email);
        User GetUserByEmail(string email);
        User GetUser(long id);
    }
}