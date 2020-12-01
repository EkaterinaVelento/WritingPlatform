using Models.Users;
using System.Collections.Generic;


namespace Service.Abstractions
{
    public interface IUserService
    {
        void Create(NewUserModel model);
        UserModel GetById(int id);
        IEnumerable<UserModel> GetAll();
        void Update(UserModel model);
        void DeleteById(int id);
    }
}