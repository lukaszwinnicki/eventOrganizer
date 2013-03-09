using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.DAL.Abstract
{
    public interface ICommentRepository
    {
        long Add(Comment comment);    
    }
}