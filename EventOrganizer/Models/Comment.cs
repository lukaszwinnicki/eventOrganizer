namespace EventOrganizer.Web.Models
{
    public class Comment : IEntity
    {
        public long Id { get; set; }
        public User Member { get; set; }
        public string Message { get; set; }
        public long EventId { get; set; }
    }
}