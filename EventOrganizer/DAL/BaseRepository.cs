using System.Collections.Generic;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using ServiceStack.Redis;

namespace EventOrganizer.Web.DAL
{
    public abstract class BaseRepository<T> : IRepository<T> where T : IEntity
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

        public IList<T> GetAll()
        {
            using (var users = Client.As<T>())
            {
                return users.GetAll();
            }
        }

        public virtual long Add(T entity)
        {
            using (var groups = Client.As<T>())
            {
                var id = groups.GetNextSequence();
                entity.Id = id;
                groups.Store(entity);
                return id;
            }
        }
    }
}