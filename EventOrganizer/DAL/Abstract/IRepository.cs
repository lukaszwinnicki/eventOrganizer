using System.Collections.Generic;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.DAL.Abstract
{
    public interface IRepository
    {
        void AddUser(User user);
        IEnumerable<User> GetAllUers();
        User GetUserByEmail(string email);
        User GetUserById(long id);
    }
}