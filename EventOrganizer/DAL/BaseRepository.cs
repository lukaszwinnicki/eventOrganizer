using System.Collections.Generic;
using EventOrganizer.Web.DAL.Abstract;
using ServiceStack.Redis;

namespace EventOrganizer.Web.DAL
{
    public abstract class BaseRepository<T> : IRepository<T>
    {
        protected readonly IRedisClient Client;

        protected BaseRepository(IRedisClient client)
        {
            Client = client;
        }

        public T GetById(long id)
        {
            using (var users = Client.As<T>())
            {
                return users.GetById(id);
            }
        }

        public IList<T> GetAllUers()
        {
            using (var users = Client.As<T>())
            {
                return users.GetAll();
            }
        }
    }
}