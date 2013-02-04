using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services;
using NUnit.Framework;
using Rhino.Mocks;

namespace EventOrganizer.Web.Tests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        private UserService _sut;

        [SetUp]
        public void Before()
        {
            _sut = new UserService(new StaticRepository());
        }

        [Test]
        public void IsEmailAvailable_EmptyList_ShouldReturnTrue()
        {
            var result = _sut.IsEmailAvailable("NonExistingEmail");

            Assert.IsTrue(result);
        }

        [Test]
        public void IsEmailAvailable_UserAddedFirst_ShouldReturnFalse()
        {
            // arrange
            const string email = "ExistingEmail";
            _sut.AddUser(new User { Email = email});
            // act
            var result = _sut.IsEmailAvailable(email);
            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CanAuthorize_WrongUser_ShouldReturnFalse()
        {
            var result = _sut.CanAuthorize("WrongEmail", "");

            Assert.IsFalse(result);
        }

        [Test]
        public void CanAuthorize_WrongPassword_ReturnFalse()
        {
            const string password = "s3cr3t";
            const string email = "Email";
            _sut.AddUser(new User {Email = email, Password = password});

            var result = _sut.CanAuthorize(email, "Wrong" + password);
            
            Assert.IsFalse(result);
        }

        [Test]
        public void CanAuthorize_CorrectData_ReturnTrue()
        {
            const string password = "s3cr3t";
            const string email = "Email";
            _sut.AddUser(new User { Email = email, Password = password });

            var result = _sut.CanAuthorize(email, password);

            Assert.IsTrue(result);            
        }
    }

}