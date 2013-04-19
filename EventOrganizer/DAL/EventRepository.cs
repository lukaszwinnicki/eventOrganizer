using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.DAL
{
    public class EventRepository : BaseRepository, IEventRepository
    {
        public EventRepository(string connectionString) : base(connectionString)
        {
        }

        public IList<Event> GetAll()
        {
            using (var connection = OpenConnection())
            {
                const string sql = "SELECT * FROM [Events]";

                return connection.Query<Event>(sql).ToList();
            }
        }

        public Event GetById(long eventId)
        {
            using (var connection = OpenConnection())
            {
                const string sql = "SELECT * FROM [Events] WHERE Id = @EventId";

                return connection.Query<Event>(sql, new {EventId = eventId}).FirstOrDefault();
            }
        }

        public long Save(Event eventToSave)
        {
            using (var connection = OpenConnection())
            {
                const string sql = "INSERT INTO [Events] ([Name], StartDate, EndDate, Address, GroupId) VALUES (@Name, @StartDate, @EndDate, @Address, @GroupId);" +
                    "SELECT cast(scope_identity() as int)";

                return connection.Execute(sql,
                                   new
                                       {
                                           eventToSave.Name,
                                           eventToSave.StartDate,
                                           eventToSave.EndDate,
                                           eventToSave.Address,
                                           eventToSave.GroupId
                                       });
            }
        }

        public void UpdatePhoto(int id, string photoUrl)
        {
            using (var connection = OpenConnection())
            {
                var sql = "UPDATE [Events] SET PhotoUrl = @Photo WHERE Id = @Id";

                connection.Execute(sql, new {Id = id, Photo = photoUrl});
            }
        }

        public Event GetById(int eventId)
        {
            using (var connection = OpenConnection())
            {
                const string sql = "SELECT * FROM [Events] WHERE Id = @EventId";

                return connection.Query<Event>(sql, new { EventId = eventId }).FirstOrDefault();
            }
        }

        public IList<Event> GetEvents(long groupId)
        {
            using (var connection = OpenConnection())
            {
                const string query =
                    "SELECT * FROM [Events] WHERE GroupId = @GroupId";

                return connection.Query<Event>(query, new { GroupId = groupId }).ToList();
            }
        }
    }
}