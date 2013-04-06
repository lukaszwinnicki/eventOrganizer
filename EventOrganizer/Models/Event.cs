using System;
using System.Collections.Generic;
using System.Web;

namespace EventOrganizer.Web.Models
{
    public class Event : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public HttpPostedFileBase Photo { get; set; }
        public List<User> Participants { get; set; }
        public List<Comment> Comments { get; set; }
        public long GroupId { get; set; }
    }
}