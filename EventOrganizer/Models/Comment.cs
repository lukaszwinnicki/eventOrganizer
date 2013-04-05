using System;

namespace EventOrganizer.Web.Models
{
    public class Comment
    {
        public long Id { get; set; }
        public User User { get; set; }
        public string Message { get; set; }
        public long EventId { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}