using System;
using System.Collections.Generic;
using System.Linq;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.Tests.Services
{
    public class StaticUserRepository : IUserRepository
    {
        private readonly IList<User> _users = new List<User>(); 

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public IList<User> GetAll()
        {
            return _users;
        }

        public User GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(x => string.Equals(email, x.Email, StringComparison.InvariantCultureIgnoreCase));
        }

        public IList<User> GetMembers(long id)
        {
            return new List<User>();
        }

        public long Update(User member)
        {
            return member.Id;
        }

        public User GetById(long id)
        {
            return _users.SingleOrDefault(x => x.Id == id);
        }

        public long Add(User entity)
        {
            _users.Add(entity);
            return entity.Id;
        }
    }
}