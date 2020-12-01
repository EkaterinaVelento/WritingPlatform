using Data.Abstractions.Repositories;
using Data.Entity;
using System.Data.Entity;


namespace Data.Repositories
{
    internal class RatingRepository : Repository<Rating>, IRatingRepository
    {
        public RatingRepository(DbContext context) : base(context) { }
    }
}