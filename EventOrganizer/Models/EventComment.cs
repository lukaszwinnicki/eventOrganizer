using System;

namespace EventOrganizer.Web.Models
{
    public class EventComment
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Message { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User User { get; set; }
    }
}