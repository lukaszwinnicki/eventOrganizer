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
            PhotoUrl = user.PhotoUrl;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoUrl { get; set; }
    }
}