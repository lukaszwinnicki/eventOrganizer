using System.Linq;
using EventOrganizer.Web.DAL;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using NUnit.Framework;

namespace EventOrganizer.Web.Tests.DAL
{
    [TestFixture]
    public class UserRepositoryTest : BaseRepositoryTest
    {
        private IUserRepository _sut;
        private GroupRepository _groupRepository;
        private const string Email = "sample@email.com";

        [SetUp]
        public void SetUp()
        {
            _sut = new UserRepository(Client);
            _groupRepository = new GroupRepository(Client);
        }


        [Test]
        public void GetAllUsers_UserExists_ShouldReturnOneUser()
        {
            AddSampleUser();

            var result = _sut.GetAllUers();

            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void GetByEmail_UserExists_ShouldReturnUser()
        {
            AddSampleUser();

            var user = _sut.GetUserByEmail(Email);

            Assert.AreEqual(Email, user.Email);
        }

        [Test]
        public void GetGroupMembers_OneGroupWithOneMemberExist_ReturnOneMember()
        {
            var group = GetGroup();
            _groupRepository.AddGroup(group);

            var groupMembers = _sut.GetMembers(group.Id);

            Assert.AreEqual(1, groupMembers.Count);
        }

        private void AddSampleUser()
        {
            _sut.AddUser(new User {Email = Email, Password = "s3cr3t"});
        }
    }
}
