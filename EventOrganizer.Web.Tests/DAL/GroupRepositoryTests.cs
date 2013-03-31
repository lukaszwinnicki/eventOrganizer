using System.Configuration;
using EventOrganizer.Web.DAL;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using NUnit.Framework;

namespace EventOrganizer.Web.Tests.DAL
{
    [TestFixture]
    public class GroupRepositoryTests
    {
        private IGroupRepository _groupRepository;

        [SetUp]
        public void SetUp()
        {
            _groupRepository = new GroupRepository(ConfigurationManager.ConnectionStrings[Constants.ConnectionStringKey].ConnectionString);
        }


        [Test]
        public void AddGroup_EmptyGroupList_OneGroupExists()
        {
            long groupId =
                _groupRepository.Save(GetGroup());

            Assert.Greater(groupId, 0);
        }

        [Test]
        public void GetGroups_OneGroupForUser_ReturnsOneGorup()
        {
            var group = GetGroup();
            _groupRepository.Save(group);

            var groups = _groupRepository.GetGroup(1);

            Assert.Greater(groups.Count, 0);
        }

        [Test]
        public void GetById_ReturnOneGroup()
        {
            long groupId = _groupRepository.Save(GetGroup());
            Group group = _groupRepository.GetById(groupId);

            Assert.AreEqual(groupId, group.Id);
        }

        private static Group GetGroup()
        {
            return new Group { Description = "Test Group Description", Name = "Test Group", OwnerId = 1 };
        }
    }
}
