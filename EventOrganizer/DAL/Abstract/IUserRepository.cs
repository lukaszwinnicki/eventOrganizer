using System.Collections.Generic;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.DAL.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByEmail(string email);
        IList<User> GetMembers(long id);
    }
}