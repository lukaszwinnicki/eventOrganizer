using System.Collections.Generic;

namespace EventOrganizer.Web.DAL.Abstract
{
    public interface IRepository<T>
    {
        IList<T> GetAll();
        T GetById(long id);
        long Add(T entity);
    }
}