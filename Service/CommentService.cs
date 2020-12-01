using Data.Abstractions;
using Data.Entity;
using Models.Comments;
using Service.Abstractions;
using Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Service
{
    public class CommentService : ICommentService
    {
        private readonly IDataUnitOfWork _uow;

        public CommentService(IDataUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Create(NewCommentModel model)
        {
            var entity = MapperService.Instance.Map<NewCommentModel, Comment>(model);
            _uow.CommentRepository.Create(entity);
            _uow.Commit();
        }
        public CommentModel GetById(int id)
        {
            var entity = _uow.CommentRepository.GetById(id);
            var model = MapperService.Instance.Map<Comment, CommentModel>(entity);
            return model;
        }

        public IEnumerable<CommentModel> GetAllByWritingId(int id)
        {
            var entities = _uow.CommentRepository.GetAll();
            var models = MapperService.Instance.Map<IEnumerable<CommentModel>>(entities)
                .Where(item => item.WritingId == id);
            return models;
        }

        public void Update(CommentModel model)
        {
            var entity = MapperService.Instance.Map<CommentModel, Comment>(model);
            _uow.CommentRepository.Update(entity);
            _uow.Commit();
        }

        public void DeleteById(int id)
        {
            var entity = _uow.CommentRepository.GetById(id);
            _uow.CommentRepository.Delete(entity);
            _uow.Commit();
        }

        public void DeleteAllByWritingId(int id)
        {
            var entities = _uow.CommentRepository.GetAll()
                .Where(item => item.UserId == id);
            foreach(var entity in entities)
            {
                _uow.CommentRepository.Delete(entity);
            }
            _uow.Commit();
        }
    }
}