using EventOrganizer.Web.DAL;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using NUnit.Framework;

namespace EventOrganizer.Web.Tests.DAL
{
    [TestFixture]
    public class GroupRepositoryTests : BaseRepositoryTest
    {
        private IGroupRepository _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new GroupRepository(Client);
        }

        
        [Test]
        public void AddGroup_EmptyGroupList_OneGroupExists()
        {
            var group = GetGroup();

            _sut.Add(group);

            Assert.AreEqual(1, Client.GetAll<Group>().Count);
        }

        [Test]
        public void GetGroups_OneGroupForUser_ReturnsOneGorup()
        {
            var group = GetGroup();
            _sut.Add(group);

            var groups = _sut.GetGroups(1);

            Assert.AreEqual(1, groups.Count);
        }

        [Test]
        public void AddGroupMember_NotExistingGroupMember_GroupMembersExists()
        {
//            var group = GetGroup();
//            _sut.AddGroup(group);
        }

        private new static Group GetGroup()
        {
            return new Group
                       {
                           Name = "Hello",
                           CreatorId = 1
                       };
        }
    }
}
