namespace EventOrganizer.Web.Models
{
    public class Group : IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long Id { get; set; }
        public long CreatorId { get; set; }
    }
}