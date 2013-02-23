using System.Collections.Generic;

namespace EventOrganizer.Web.DAL.Abstract
{
    public interface IRepository<T>
    {
        IList<T> GetAllUers();
        T GetById(long id);
    }
}