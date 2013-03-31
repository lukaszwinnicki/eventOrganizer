using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.DAL
{
    public class GroupRepository : BaseRepository, IGroupRepository
    {
        public GroupRepository(string connectionString)
            : base(connectionString)
        {
        }

        public IList<Group> GetGroup(long userId)
        {
            using (var connection = OpenConnection())
            {
                const string sql = "SELECT * FROM [Groups]";

                return connection.Query<Group>(sql, new {UserId = userId}).ToList();
            }
        }

        public Group GetById(long groupId)
        {
            using (var connection = OpenConnection())
            {
                const string sql = "SELECT * FROM [Groups] WHERE Id = @GroupId";

                return connection.Query<Group>(sql, new { GroupId = groupId }).FirstOrDefault();
            }
        }

        public long Save(Group groupToSave)
        {
            using (var connection = OpenConnection())
            {
                // TODO: check transactions

                const string insertGroupQuery =
                    "INSERT INTO [Groups] (Name, Description, OwnerId)" +
                    "VALUES (@Name, @Description, @OwnerId);" +
                    "SELECT cast(scope_identity() as int)";

                var groupId = connection.Query<int>(insertGroupQuery, new
                {
                    groupToSave.Name,
                    groupToSave.Description,
                    groupToSave.OwnerId
                }).First();

                const string insertConnectionQuery =
                    "INSERT INTO [UsersGroups] (UserId, GroupId) VALUES(@UserId, @GroupId)";

                connection.Execute(insertConnectionQuery, new { UserId = groupToSave.OwnerId, GroupId = groupId });

                return groupId;
            }
        }
    }
}