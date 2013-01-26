using System.Collections.Generic;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.ViewModels
{
    public class GroupsViewModel
    {
        public User User { get; set; }
        public List<Group> Groups { get; set; }
    }
}