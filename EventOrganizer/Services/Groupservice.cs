using System.Collections.Generic;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUserRepository _userRepository;

        public GroupService(IGroupRepository groupRepository, IUserRepository userRepository)
        {
            _groupRepository = groupRepository;
            _userRepository = userRepository;
        }

        public IList<Group> GetGropus(string email)
        {
            var userId = _userRepository.GetUserByEmail(email).Id;
            return _groupRepository.GetGroup(userId);
        }

        public Group Save(Group group, string email)
        {
            var userId = _userRepository.GetUserByEmail(email).Id;

            group.OwnerId = userId;
            group.Id = _groupRepository.Save(group);

            return group;
        }

        public Group GetGropu(int id)
        {
            return _groupRepository.GetById(id);
        }
    }
}