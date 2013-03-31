using System.Data;
using Dapper;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.DAL
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(string connectionString) : base(connectionString)
        {
        }

        public long Save(Comment comment)
        {
            using (IDbConnection connection = OpenConnection())
            {
                const string query =
                    "INSERT INTO Comment(UserId, Message, EventId)" +
                    "VALUES (@UserId, @Message, @EventId)";

                int rowsAffected = connection.Execute(query, new
                {
                    UserId = comment.Member.Id,
                    comment.Message,
                    comment.EventId
                });

                return rowsAffected;
            }
        }
    }
}