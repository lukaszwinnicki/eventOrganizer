using System.Collections.Generic;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Services
{
    public class GroupService : IGroupService
    {
        public IList<Group> GetGropus(string userId)
        {
            return new List<Group>
                {
                    new Group {Description = "Short description", Name = "Beer lovers 1"},
                    new Group {Description = "Short description", Name = "Beer lovers 2"},
                    new Group {Description = "Short description", Name = "Beer lovers 3"},
                    new Group {Description = "Short description", Name = "Beer lovers 4"},
                    new Group {Description = "Short description", Name = "Beer lovers 5"},
                    new Group {Description = "Short description", Name = "Beer lovers 6"},
                    new Group {Description = "Short description", Name = "Beer lovers 7"},
                    new Group {Description = "Short description", Name = "Beer lovers 8"}
                };
        }
    }
}