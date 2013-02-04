using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ServiceStack.Redis;

namespace EventOrganizer.Web.Tests.DAL
{
    [TestFixture]
    class RedisConnectionTests
    {
        private RedisClient _client;

        [SetUp]
        public void Before()
        {
            _client = new RedisClient("pub-redis-10685.eu-west-1-1.1.ec2.garantiadata.com", 10685);
        }

        
        [Test]
        public void CanConnectToServer()
        {
            var response = _client.Ping();

            Assert.IsTrue(response);
        }

        [Test]
        public void AddData()
        {
            using (var books = _client.As<Book>())
            {
                var id = books.GetNextSequence();
                books.Store(new Book { Id = id, Name = "BOOK" + id});


                var byId = books.GetById(id);
                Trace.WriteLine(string.Format("{0} - {1}", byId.Id, byId.Name));
            }
        }

        [Test]
        public void GeneratingSequenceTest()
        {
            using (var books = _client.As<Book>())
            {
                var seq1 = books.GetNextSequence();
                var seq2 = books.GetNextSequence();
                Assert.AreNotEqual(seq1, seq2);
            }
        }

        public class Book
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }
    }
}
