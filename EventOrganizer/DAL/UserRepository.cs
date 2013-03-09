using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using ServiceStack.Redis;

namespace EventOrganizer.Web.DAL
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IRedisClient client) : base(client) { }

        public override long Add(User user)
        {
            var id = base.Add(user);
            Client.Hashes["user-email-id"].Add(user.Email, id.ToString(CultureInfo.InvariantCulture));
            return id;
        }

        public User GetUserByEmail(string email)
        {
            using (var users = Client.As<User>())
            {
                var id = Client.Hashes["user-email-id"][email];
                return users.GetById(id); 
            }
        }

        public IList<User> GetMembers(long id)
        {
            var membersIds = Client.Lists["group-users-" + id];
            return membersIds.GetAll().Select(x => GetById(long.Parse(x))).ToList();
        }

        public long Update(User member)
        {
            // TODO: add logic

            return member.Id;
        }
    }
}