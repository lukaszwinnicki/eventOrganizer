using System.Collections.Generic;

namespace EventOrganizer.Web.Models
{
    public class User : IEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhotoUrl { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long Id { get; set; }
        public List<Group> Groups { get; set; }
        public string ThumbnailUrl { get; set; }

        public User()
        {
            Groups = new List<Group>();
        }
    }
}