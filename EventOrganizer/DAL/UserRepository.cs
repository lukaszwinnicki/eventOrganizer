using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.DAL
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(string connectionString)
            : base(connectionString)
        {

        }

        public long Save(User user)
        {
            using (IDbConnection connection = OpenConnection())
            {
                // TODO: check if user already exist

                const string query =
                    "INSERT INTO [Users] (Email, Name, Password, PhotoUrl, Surname, ThumbnailUrl)" +
                    "VALUES (@Email, @Name, @Password, @PhotoUrl, @Surname, @ThumbnailUrl);" +
                    "SELECT cast(scope_identity() as int)";

                return connection.Query<int>(query, new
                {
                    user.Email,
                    user.Name,
                    user.Password,
                    user.PhotoUrl,
                    user.Surname,
                    user.ThumbnailUrl
                }).First();
            }
        }

        public User GetById(long userId)
        {
            using (var connection = OpenConnection())
            {
                const string sql = "SELECT * FROM [Users] WHERE Id = @UserId";

                return connection.Query<User>(sql, new { UserId = userId }).FirstOrDefault();
            }
        }

        public List<User> GetAll()
        {
            using (var connection = OpenConnection())
            {
                const string query =
                    "SELECT * FROM [Users]";

                return connection.Query<User>(query).ToList();
            }
        }

        public List<User> GetAll(string pattern)
        {
            using (var connection = OpenConnection())
            {
                string query =
                    "SELECT * FROM [Users] u WHERE u.Name like '%" + pattern + "%' OR u.Surname like '%" + pattern +
                    "%'";

                return connection.Query<User>(query, new { Pattern = pattern }).ToList();
            }
        }

        public bool AddGroupMember(long userId, long groupId)
        {
            using (var connection = OpenConnection())
            {
                const string query = "INSERT INTO [UsersGroups](UserId, GroupId) VALUES(@UserId, @GroupId)";

                return connection.Execute(query, new
                {
                    UserId = userId,
                    GroupId = groupId,
                }) > 0;
            }
        }

        public List<EventMember> GetEventMembers(int eventId)
        {
            using (var connection = OpenConnection())
            {
                const string query =
                    "SELECT u.Id, u.Name, u.Surname, u.ThumbnailUrl FROM [Users] u LEFT JOIN [UsersEvents] ug ON ug.UserId = u.Id WHERE EventId = @EventId";

                return connection.Query<EventMember>(query, new { EventId = eventId }).ToList();
            }
        }

        public bool AddEventMember(long userId, long eventId)
        {
            using (var connection = OpenConnection())
            {
                const string query = "INSERT INTO [UsersEvents](UserId, EventId) VALUES(@UserId, @EventId)";

                return connection.Execute(query, new
                {
                    UserId = userId,
                    EventId = eventId,
                }) > 0;
            }
        }

        public bool RemoveEventMember(long userId, long eventId)
        {
            using (var connection = OpenConnection())
            {
                const string query = "DELETE FROM [UsersEvents] WHERE UserId = @UserId AND EventId = @EventId";

                return connection.Execute(query, new
                {
                    UserId = userId,
                    EventId = eventId,
                }) > 0;
            }
        }

        public User GetUserByEmail(string email)
        {
            using (var connection = OpenConnection())
            {
                const string query =
                    "SELECT * FROM [Users] WHERE Email = @Email";

                return connection.Query<User>(query, new { Email = email }).FirstOrDefault();
            }
        }

        public List<GroupMember> GetGroupMembers(long groupId)
        {
            using (var connection = OpenConnection())
            {
                const string query =
                    "SELECT u.Id, u.Name, u.Surname, u.ThumbnailUrl FROM [Users] u LEFT JOIN [UsersGroups] ug ON ug.UserId = u.Id WHERE GroupId = @GroupId";

                return connection.Query<GroupMember>(query, new { GroupId = groupId }).ToList();
            }
        }

        public bool Update(User user)
        {
            using (var connection = OpenConnection())
            {
                const string sql = "UPDATE [Users] SET Email = @Email, Password = @Password, Name = @Name, Surname = @Surname, PhotoUrl = @PhotoUrl, ThumbnailUrl = @ThumbnailUrl WHERE Id = @Id";

                return connection.Execute(sql, new { user.Id, user.Email, user.Name, user.Password, user.PhotoUrl, user.Surname, user.ThumbnailUrl }) == 1;
            }
        }
    }
}