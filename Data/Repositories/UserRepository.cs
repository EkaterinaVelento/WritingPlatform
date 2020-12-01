using Data.Abstractions.Repositories;
using Data.Entity;
using System.Data.Entity;


namespace Data.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }
    }
}