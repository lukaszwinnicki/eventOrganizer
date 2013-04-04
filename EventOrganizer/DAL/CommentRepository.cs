using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.DAL
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(string connectionString)
            : base(connectionString)
        {
        }

        public long Save(Comment comment)
        {
            using (IDbConnection connection = OpenConnection())
            {
                const string query =
                    "INSERT INTO Comments(UserId, Message, EventId)" +
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

        public List<EventComment> GetEventComments(int id)
        {
            using (var connection = OpenConnection())
            {
                const string sql = "SELECT c.Id, c.UserId, c.Message FROM Comments c WHERE c.EventId = @EventId";

                return connection.Query<EventComment>(sql, new { EventId = id }).ToList();
            }
        }
    }
}