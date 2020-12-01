using Data.Abstractions;
using Data.Entity;
using Models.Users;
using Service.Abstractions;
using Service.Mapping;
using System.Collections.Generic;


namespace Service
{
    public class UserService : IUserService
    {
        private readonly IDataUnitOfWork _uow;

        public UserService(IDataUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Create(NewUserModel model)
        {
            model.Password = Crypto.Hash(model.Password);
            var entity = MapperService.Instance.Map<NewUserModel, User>(model);
            _uow.UserRepository.Create(entity);
            _uow.Commit();
        }
        public UserModel GetById(int id)
        {
            var entity = _uow.UserRepository.GetById(id);
            var model = MapperService.Instance.Map<User, UserModel>(entity);
            return model;
        }

        public IEnumerable<UserModel> GetAll()
        {
            var entities = _uow.UserRepository.GetAll();
            var models = MapperService.Instance.Map<IEnumerable<UserModel>>(entities);
            return models;
        }
        public void Update(UserModel model)
        {
            var entity = MapperService.Instance.Map<UserModel, User>(model);
            _uow.UserRepository.Update(entity);
            _uow.Commit();
        }

        public void DeleteById(int id)
        {
            var entity = _uow.UserRepository.GetById(id);
            entity.IsDeleted = true;
            _uow.UserRepository.Update(entity);
            _uow.Commit();
        }
    }
}