﻿using System;
using System.Collections.Generic;

namespace EventOrganizer.Web.Models
{
    public class Event : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime When { get; set; }
        public TimeSpan Duration { get; set; }
        public Address Address { get; set; }
        public List<string> EventPhotos { get; set; }
        public List<User> Participants { get; set; }

        public long GroupId { get; set; }
    }
}