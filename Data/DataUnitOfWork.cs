using Data.Abstractions;
using Data.Abstractions.Repositories;
using Data.Repositories;


namespace Data
{
    public class DataUnitOfWork : IDataUnitOfWork
    {
        private readonly DataDbContext _context;
        private IUserRepository _userRepository;
        private IWritingRepository _writingRepository;
        private ICommentRepository _commentRepository;
        private IRatingRepository _ratingRepository;

        public DataUnitOfWork(string connectionString)
        {
            _context = new DataDbContext(connectionString);
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        public IWritingRepository WritingRepository
        {
            get
            {
                if (_writingRepository == null)
                {
                    _writingRepository = new WritingRepository(_context);
                }
                return _writingRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new CommentRepository(_context);
                }
                return _commentRepository;
            }
        }

        public IRatingRepository RatingRepository
        {
            get
            {
                if (_ratingRepository == null)
                {
                    _ratingRepository = new RatingRepository(_context);
                }
                return _ratingRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}