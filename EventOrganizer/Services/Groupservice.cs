using System.Collections.Generic;
using System.Linq;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Services
{
    public class GroupService : IGroupService
    {
        private static List<Group> _groups;

        public GroupService()
        {
            _groups = new List<Group>
                {
                    new Group {Id = 1, Description = "Short description", Name = "Beer lovers 1"},
                    new Group {Id = 2, Description = "Short description", Name = "Beer lovers 2"},
                    new Group {Id = 3, Description = "Short description", Name = "Beer lovers 3"},
                    new Group {Id = 4, Description = "Short description", Name = "Beer lovers 4"},
                    new Group {Id = 5, Description = "Short description", Name = "Beer lovers 5"},
                    new Group {Id = 6, Description = "Short description", Name = "Beer lovers 6"},
                    new Group {Id = 7, Description = "Short description", Name = "Beer lovers 7"},
                    new Group {Id = 8, Description = "Short description", Name = "Beer lovers 8"}
                };
        }

        public IList<Group> GetGropus(string userId)
        {
            return _groups;
        }

        public Group Save(Group group)
        {
            _groups.Add(group);

            return group;
        }

        public Group GetGropu(int id)
        {
            return _groups.FirstOrDefault(g => g.Id == id);
        }
    }
}