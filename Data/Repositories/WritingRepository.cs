using Data.Abstractions.Repositories;
using Data.Entity;
using System.Data.Entity;


namespace Data.Repositories
{
    internal class WritingRepository : Repository<Writing>, IWritingRepository
    {
        public WritingRepository(DbContext context) : base(context) { }
    }
}