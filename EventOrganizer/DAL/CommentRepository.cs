using System.Globalization;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using ServiceStack.Redis;

namespace EventOrganizer.Web.DAL
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(IRedisClient client)
            : base(client)
        {
        }

        public override long Add(Comment comment)
        {
            var id = base.Add(comment);
            Client.Lists["event-comments" + comment.EventId].Add(id.ToString(CultureInfo.InvariantCulture));

            return id;
        }
    }
}