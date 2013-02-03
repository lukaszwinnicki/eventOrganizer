using System;
using System.Collections.Generic;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Services
{
    public class EventService : IEventService
    {
        public IList<Event> GetEvents(int groupId, string userId)
        {
            return new List<Event>
                {
                    new Event
                        {
                            Id = 1,
                            Address = new Address
                                {
                                    City = "Gdańsk",
                                    Street = "ul. Piwna 59/60/5"
                                },
                            Duration = new TimeSpan(0, 6, 0),
                            EventPhotos = new List<string>
                                {
                                    "1.png"
                                },
                            Name = "Event 1",
                            Participants = new List<User>
                                {

                                },
                            When = new DateTime(2013, 8, 8)
                        }
                };
        }
    }
}