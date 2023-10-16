using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Entities;

namespace TatBlog.Services.Blogs
{
    public interface ICommentRepository
    {
        Comment GetCommentById(int id);

        IEnumerable<Comment> GetCommentsByPostId(int postId);

        void AddComment(Comment comment);

        void UpdateComment(Comment comment);

        void DeleteComment(Comment comment);
    }
}
