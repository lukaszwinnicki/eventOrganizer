using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using ServiceStack.Redis;

namespace EventOrganizer.Web.DAL
{
    public class Repository : IRepository
    {
        private readonly IRedisClient _client;

        public Repository(IRedisClient client)
        {
            _client = client;
        }

        public void AddUser(User user)
        {
            using (var users = _client.As<User>())
            {
                
                var id = users.GetNextSequence();
                user.Id = id;
                users.Store(user);
                _client.Hashes["user-email-id"].Add(user.Email, id.ToString());
            }
        }

        public IEnumerable<User> GetAllUers()
        {
            using (var users = _client.As<User>())
            {
                return users.GetAll();
            }
        }

        public User GetUserByEmail(string email)
        {
            using (var users = _client.As<User>())
            {
                var id = _client.Hashes["user-email-id"][email];
                return users.GetById(id);
            }
        }

        public User GetUserById(long id)
        {
            using (var users = _client.As<User>())
            {
                return users.GetById(id);
            }
        }
    }
}