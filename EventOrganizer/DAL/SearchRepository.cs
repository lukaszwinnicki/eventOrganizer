using Dapper;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using ServiceStack.Common.Extensions;
using System.Linq;

namespace EventOrganizer.Web.DAL
{
    public class SearchRepository : BaseRepository, ISearchRepository
    {
        public SearchRepository(string connectionString) : base(connectionString)
        {
        }

        public SearchResult GetSearchItems(string pattern)
        {
            var result = new SearchResult();
            using (var connection = OpenConnection())
            {
                var sql = "SELECT Id, Name, 'Events' as Type FROM [Events] WHERE Name like '%' + @Pattern + '%'" +
                          "UNION " +
                          "SELECT Id, Name, 'Groups' as Type FROM [Groups] WHERE Name like '%' + @Pattern + '%'" +
                          "UNION " +
                          "SELECT Id, Name, 'Users' as Type FROM [Users] WHERE Name like '%' + @Pattern + '%'";

                var items = connection.Query(sql, new {Pattern = pattern}).ToList();

                result.Events = items.Where(x => x.Type == "Events")
                    .Select(x => new SearchResultItem { Id = x.Id, Name = x.Name}).ToList();
                result.Groups = items.Where(x => x.Type == "Groups")
                    .Select(x => new SearchResultItem { Id = x.Id, Name = x.Name}).ToList();
                result.Users = items.Where(x => x.Type == "Users")
                    .Select(x => new SearchResultItem { Id = x.Id, Name = x.Name}).ToList();
                return result;
            }
        }
    }
}