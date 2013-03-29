using EventOrganizer.Web.DAL;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using NUnit.Framework;

namespace EventOrganizer.Web.Tests.DAL
{
    [TestFixture]
    public class EventRepostitoryTests : BaseRepositoryTest
    {
        private IEventRepository _sut;

        [SetUp]
        public new void Before()
        {
            _sut = new EventRepository(Client);
        }

        
        [Test]
        public void AddEvent_EmptyDB_ShouldReturnOneEvent()
        {
            var @event = new Event
                             {
                                 Name = "sadlaskd"
                             };
            // act
            _sut.Add(@event);
            
            Assert.AreEqual(1, _sut.GetAll().Count);
        }

        [Test]
        public void GetEvent_OneEventForGroup_ReturnsOneEvent()
        {
            var @event = AddEvent();

            var events = _sut.GetEvents(@event.GroupId);

            Assert.AreEqual(1, events.Count);
        }

        public Event AddEvent()
        {
            var @event = new Event
            {
                Name = "sadlaskd",
                GroupId = 1
            };

            _sut.Add(@event);

            return @event;
        }
    }
}
