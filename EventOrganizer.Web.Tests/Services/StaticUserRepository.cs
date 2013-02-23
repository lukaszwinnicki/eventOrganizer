using System;
using System.Collections.Generic;
using System.Linq;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.Tests.Services
{
    public class StaticUserRepository : IUserRepository
    {
        private IList<User> Users = new List<User>(); 
        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public IList<User> GetAllUers()
        {
            return Users;
        }

        public User GetUserByEmail(string email)
        {
            return Users.SingleOrDefault(x => string.Equals(email, x.Email, StringComparison.InvariantCultureIgnoreCase));
        }

        public IList<User> GetMembers(long id)
        {
            throw new NotImplementedException();
        }

        public User GetById(long id)
        {
            return Users.SingleOrDefault(x => x.Id == id);
        }
    }
}