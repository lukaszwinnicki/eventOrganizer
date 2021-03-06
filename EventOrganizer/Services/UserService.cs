﻿using System.Collections.Generic;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Save(User user)
        {
            _userRepository.Save(user);
        }

        public bool CanAuthorize(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);
            return user != null && string.Equals(user.Password, password);
        }

        public bool IsEmailAvailable(string email)
        {
            return _userRepository.GetUserByEmail(email) == null;
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public User GetUser(long id)
        {
            return _userRepository.GetById(id);
        }

        public bool Update(User member)
        {
            return _userRepository.Update(member);
        }

        public List<EventMember> GetEventMembers(int eventId)
        {
            return _userRepository.GetEventMembers(eventId);
        }

        public bool AddEventMember(long userId, long eventId)
        {
            return _userRepository.AddEventMember(userId, eventId);
        }

        public bool RemoveEventMember(long userId, long eventId)
        {
            return _userRepository.RemoveEventMember(userId, eventId);
        }

        public List<GroupMember> GetGroupMembers(int groupId)
        {
            return _userRepository.GetGroupMembers(groupId);
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetAll();
        }

        public List<User> GetUsers(string pattern)
        {
            return _userRepository.GetAll(pattern);
        }

        public void AddGroupMember(long userId, long groupId)
        {
            _userRepository.AddGroupMember(userId, groupId);
        }
    }
}