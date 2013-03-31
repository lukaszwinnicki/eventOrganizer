using System;
using System.Collections.Generic;

namespace EventOrganizer.Web.Models
{
    public class Event : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime When { get; set; }
        public TimeSpan Duration { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public List<string> EventPhotos { get; set; }
        public List<User> Participants { get; set; }
        public List<Comment> Comments { get; set; }
        public long GroupId { get; set; }
    }
}