using Data.Abstractions;
using Data.Entity;
using Models.Writings;
using Service.Abstractions;
using Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Service
{
    public class WritingService : IWritingService
    {
        private readonly IDataUnitOfWork _uow;

        public WritingService(IDataUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Create(NewWritingModel model)
        {
            var entity = MapperService.Instance.Map<NewWritingModel, Writing>(model);
            _uow.WritingRepository.Create(entity);
            _uow.Commit();
        }

        public IEnumerable<WritingModel> GetByUserId(int id)
        {
            var entities = _uow.WritingRepository.GetAll().Where(item=>item.UserId == id);
            var models = MapperService.Instance.Map<IEnumerable<WritingModel>>(entities);
            return models;
        }

        public WritingModelWithComments GetById(int id)
        {
            var entity = _uow.WritingRepository.GetById(id);
            var model = MapperService.Instance.Map<Writing, WritingModelWithComments>(entity);
            return model;
        }

        public IEnumerable<WritingModel> GetAll()
        {
            var entities = _uow.WritingRepository.GetAll();
            var models = MapperService.Instance.Map<IEnumerable<WritingModel>>(entities);
            return models;
        }

        public void Update(WritingModel model)
        {
            var entity = MapperService.Instance.Map<WritingModel, Writing>(model);
            _uow.WritingRepository.Update(entity);
            _uow.Commit();
        }

        public void DeleteById(int id)
        {
            var entity = _uow.WritingRepository.GetById(id);
            _uow.WritingRepository.Delete(entity);
            _uow.Commit();
        }

        public void Publish(WritingPublishingModel model)
        {
            var entity = _uow.WritingRepository.GetById(model.Id);
            entity.Published = DateTime.UtcNow;
            _uow.WritingRepository.Update(entity);
            _uow.Commit();
        }
    }
}