using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.Services.Abstract
{
    public interface ICommentService
    {
        long Save(Comment comment);
    }
}