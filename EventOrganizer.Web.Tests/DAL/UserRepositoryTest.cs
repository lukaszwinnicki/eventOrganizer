using System.Configuration;
using EventOrganizer.Web.DAL;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using NUnit.Framework;

namespace EventOrganizer.Web.Tests.DAL
{
    [TestFixture]
    public class UserRepositoryTest
    {
        private IUserRepository _userRepository;
        private GroupRepository _groupRepository;
        private const string Email = "sample@email.com";

        [SetUp]
        public void SetUp()
        {
            _userRepository = new UserRepository(ConfigurationManager.ConnectionStrings[Constants.ConnectionStringKey].ConnectionString);
            _groupRepository = new GroupRepository(ConfigurationManager.ConnectionStrings[Constants.ConnectionStringKey].ConnectionString);
        }

        [Test]
        public void SaveMethodShouldReturnIdOfCreatedUser()
        {
            long userId = _userRepository.Save(new User
                {
                    Email = "test@test.pl",
                    Name = "Name",
                    Password = "Password",
                    PhotoUrl = "PhotoUrl",
                    Surname = "Surname"
                });

            Assert.Greater(userId, 0);
        }

        [Test]
        public void GetAllUsers_UserExists_ShouldReturnOneUser()
        {
            AddSampleUser();

            var result = _userRepository.GetAll();

            Assert.Greater(result.Count, 0);
        }

        [Test]
        public void GetByEmail_UserExists_ShouldReturnUser()
        {
            AddSampleUser();

            var user = _userRepository.GetUserByEmail(Email);

            Assert.AreEqual(Email, user.Email);
        }

        [Test]
        public void GetGroupMembers_OneGroupWithOneMemberExist_ReturnOneMember()
        {
            long userId = AddSampleUser();
            long groupId =
                _groupRepository.Save(new Group
                    {Description = "Test Group Description", Name = "Test Group", OwnerId = userId});

            var groupMembers = _userRepository.GetGroupMembers(groupId);

            Assert.Greater(groupMembers.Count, 0);
        }

        [Test]
        public void UpdateUser_ReturnTrueWhenUserExists()
        {
            var user = new User
                {
                    Email = Email,
                    Name = "Name",
                    Password = "Password",
                    PhotoUrl = "PhotoUrl",
                    Surname = "Surname"
                };
            user.Id = _userRepository.Save(user);

            bool result = _userRepository.Update(user);

            Assert.AreEqual(true, result);
        }

        private long AddSampleUser()
        {
            return _userRepository.Save(new User
            {
                Email = Email,
                Name = "Name",
                Password = "Password",
                PhotoUrl = "PhotoUrl",
                Surname = "Surname"
            });
        }
    }
}