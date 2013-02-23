using System.Collections.Generic;
using System.Linq;
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
            return _groupRepository.GetGroups(userId);
        }

        public Group Save(Group group)
        {
            _groupRepository.Add(group);

            return group;
        }

        public Group GetGropu(int id)
        {
            return _groupRepository.GetById(id);
        }
    }
}