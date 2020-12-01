using Data.Abstractions.Repositories;
using Data.Entity;
using System.Data.Entity;


namespace Data.Repositories
{
    internal class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context) { }
    }
}