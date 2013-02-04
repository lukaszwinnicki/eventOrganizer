using System;
using System.Collections.Generic;
using System.Linq;
using EventOrganizer.Web.DAL;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public void AddUser(User user)
        {
            _repository.AddUser(user);
        }

        public bool CanAuthorize(string email, string password)
        {
            var user = _repository.GetUserByEmail(email);
            return user != null && string.Equals(user.Password, password);
        }

        public bool IsEmailAvailable(string email)
        {
            return _repository.GetUserByEmail(email) == null;
        }

        public User GetUserByEmail(string email)
        {
            return _repository.GetUserByEmail(email);
        }

        public User GetUser(long id)
        {
            return _repository.GetUserById(id);
        }
    }
}