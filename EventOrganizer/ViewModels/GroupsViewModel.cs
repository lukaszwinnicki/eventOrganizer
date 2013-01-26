using System.Collections.Generic;
using EventOrganizer.Models;
using Group = EventOrganizer.Models.Group;

namespace EventOrganizer.ViewModels
{
    public class GroupsViewModel
    {
        public User User { get; set; }
        public List<Group> Groups { get; set; }
    }
}