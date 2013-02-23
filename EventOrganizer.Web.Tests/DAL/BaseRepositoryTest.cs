using EventOrganizer.Web.Models;
using NUnit.Framework;
using ServiceStack.Redis;

namespace EventOrganizer.Web.Tests.DAL
{
    public class BaseRepositoryTest
    {
        protected RedisClient Client;

        [TestFixtureSetUp]
        public void Clean()
        {
            Client = new RedisClient("pub-redis-10685.eu-west-1-1.1.ec2.garantiadata.com", 10685);
        }

        [SetUp]
        public void Before()
        {
            Client.FlushDb();
            Client.FlushAll();
            Assert.AreEqual(0, Client.GetAllKeys().Count, "db should be empty");
        }

        protected static Group GetGroup()
        {
            return new Group
            {
                Name = "Hello",
                CreatorId = 1
            };
        }
    }
}