using System;
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
                    "INSERT INTO Comments(UserId, Message, EventId, UpdatedAt)" +
                    "VALUES (@UserId, @Message, @EventId, @UpdatedAt)";

                var rowsAffected = connection.Execute(query, new
                {
                    UserId = comment.User.Id,
                    comment.Message,
                    comment.EventId,
                    UpdatedAt = comment.UpdatedAt
                });

                return rowsAffected;
            }
        }

        public List<EventComment> GetEventComments(int id)
        {
            using (var connection = OpenConnection())
            {
                const string sql = "SELECT * FROM Comments c LEFT JOIN [Users] u ON u.Id = c.UserId WHERE c.EventId = @EventId";

                return connection.Query<EventComment, User, EventComment>(sql, (eventComment, user) =>
                    { eventComment.User = user;
                        return eventComment;
                    }, new { EventId = id }).ToList();
            }
        }
    }
}