using System;
using System.Collections.Generic;
using System.Configuration;
using EventOrganizer.Web.DAL;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using NUnit.Framework;

namespace EventOrganizer.Web.Tests.DAL
{
    [TestFixture]
    public class EventRepostitoryTests
    {
        private IEventRepository _eventRepository;

        [SetUp]
        public void Before()
        {
            _eventRepository = new EventRepository(ConfigurationManager.ConnectionStrings[Constants.ConnectionStringKey].ConnectionString);
        }
        
        [Test]
        public void AddEvent_EmptyDB_ShouldReturnOneEvent()
        {
            var eventToSave = new Event
                             {
                                 Name = "sadlaskd",
                                 StartDate = DateTime.Now,
                                 EndDate = DateTime.Now.AddHours(4),
                                 Address = "City",
                                 GroupId = 1
                             };

            _eventRepository.Save(eventToSave);
            IList<Event> events = _eventRepository.GetAll();

            Assert.Greater(events.Count, 0);
        }

        [Test]
        public void GetEvent_OneEventForGroup_ReturnsOneEvent()
        {
            var @event = AddEvent();

            var events = _eventRepository.GetEvents(@event.GroupId);

            Assert.Greater(events.Count, 0);
        }

        public Event AddEvent()
        {
            var @event = new Event
                {
                    Name = "sadlaskd",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddHours(1),
                    Address = "City",
                    GroupId = 1
                };

            long eventId = _eventRepository.Save(@event);
            @event.Id = eventId;

            return @event;
        }
    }
}
