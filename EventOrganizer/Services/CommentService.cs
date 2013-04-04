using System.Collections.Generic;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public long Save(Comment comment)
        {
            return _commentRepository.Save(comment);
        }

        public List<EventComment> GetEventComments(int id)
        {
            return _commentRepository.GetEventComments(id);
        }
    }
}