using System.Collections.Generic;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.DAL.Abstract
{
    public interface ICommentRepository
    {
        long Save(Comment comment);
        List<EventComment> GetEventComments(int id);
    }
}