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
                const string sql = "INSERT INTO [Events] ([Name], [When], Duration, Country, City, Street, HouseNumber, GroupId) VALUES (@Name, @When, @Duration, @Country, @City, @Street, @HouseNumber, @GroupId);" +
                    "SELECT cast(scope_identity() as int)";

                return connection.Execute(sql,
                                   new
                                       {
                                           eventToSave.Id,
                                           eventToSave.Name,
                                           eventToSave.When,
                                           eventToSave.Duration,
                                           eventToSave.Country,
                                           eventToSave.City,
                                           eventToSave.Street,
                                           eventToSave.HouseNumber,
                                           eventToSave.GroupId
                                       });
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