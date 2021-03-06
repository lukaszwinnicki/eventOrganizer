﻿using System.Collections.Generic;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.Services.Abstract
{
    public interface IEventService
    {
        IList<Event> GetEvents(int groupId);
        Event GetEvent(int id);
        long Save(Event eventToSave);
        bool Update(int id, Event eventToUpdate);
        void UpdatePhoto(int id, string photoUrl);
    }
}