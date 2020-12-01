using Base.Abstractions;
using Data.Abstractions.Repositories;


namespace Data.Abstractions
{
    public interface IDataUnitOfWork : IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IWritingRepository WritingRepository { get; }
        ICommentRepository CommentRepository { get; }
        IRatingRepository RatingRepository { get; }
    }
}