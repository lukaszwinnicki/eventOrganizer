namespace EventOrganizer.Web.Models
{
    public class EventMember
    {
        public EventMember()
        {
            
        }

        public EventMember(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Surname = user.Surname;
            ThumbnailUrl = user.PhotoUrl;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}