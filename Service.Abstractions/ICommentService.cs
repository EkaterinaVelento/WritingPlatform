using Models.Comments;
using System.Collections.Generic;


namespace Service.Abstractions
{
    public interface ICommentService
    {
        void Create(NewCommentModel model);
        CommentModel GetById(int id);
        IEnumerable<CommentModel> GetAllByWritingId(int id);
        void Update(CommentModel model);
        void DeleteById(int id);
        void DeleteAllByWritingId(int id);
    }
}