using Base.Abstractions;
using Data.Entity;


namespace Data.Abstractions.Repositories
{
    public interface IUserRepository : IRepository<User> { }
}