namespace EventOrganizer.Web.Models
{
    public class EventComment
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Message { get; set; }
    }
}