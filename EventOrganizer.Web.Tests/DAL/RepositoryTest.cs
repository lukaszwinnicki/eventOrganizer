using System.Linq;
using EventOrganizer.Web.DAL;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using NUnit.Framework;
using ServiceStack.Redis;

namespace EventOrganizer.Web.Tests.DAL
{
    [TestFixture]
    public class RepositoryTest
    {
        private const string Email = "sample@email.com";
        private IRepository _sut;
        private RedisClient _client;

        [TestFixtureSetUp]
        public void Clean()
        {
            _client = new RedisClient("pub-redis-10685.eu-west-1-1.1.ec2.garantiadata.com", 10685);
        }

        [SetUp]
        public void Before()
        {
            _client.FlushDb();
            _client.FlushAll();
            Assert.AreEqual(0, _client.GetAllKeys().Count, "db should be empty");
            _sut = new Repository(_client);
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

        private void AddSampleUser()
        {
            _sut.AddUser(new User {Email = Email, Password = "s3cr3t"});
        }
    }
}
