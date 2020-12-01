using Data.Abstractions;
using Data.Entity;
using Models.Ratings;
using Service.Abstractions;
using Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Service
{
    public class RatingService : IRatingService
    {
        private readonly IDataUnitOfWork _uow;

        public RatingService(IDataUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Create(NewRatingModel model)
        {
            var entity = MapperService.Instance.Map<NewRatingModel, Rating>(model);
            _uow.RatingRepository.Create(entity);
            _uow.Commit();
        }
        public RatingModel GetById(int id)
        {
            var entity = _uow.RatingRepository.GetById(id);
            var model = MapperService.Instance.Map<Rating, RatingModel>(entity);
            return model;
        }

        public IEnumerable<RatingModel> GetAllByWritingId(int id)
        {
            var entities = _uow.RatingRepository.GetAll();
            var models = MapperService.Instance.Map<IEnumerable<RatingModel>>(entities).Where(item => item.WritingId == id);
            return models;
        }

        public void Update(RatingModel model)
        {
            var entity = MapperService.Instance.Map<RatingModel, Rating>(model);
            _uow.RatingRepository.Update(entity);
            _uow.Commit();
        }

        public void DeleteById(int id)
        {
            var entity = _uow.RatingRepository.GetById(id);
            _uow.RatingRepository.Delete(entity);
            _uow.Commit();
        }

        public void DeleteAllByWritingId(int id)
        {
            var entities = _uow.CommentRepository.GetAll()
                .Where(item => item.UserId == id);
            foreach (var entity in entities)
            {
                _uow.CommentRepository.Delete(entity);
            }
            _uow.Commit();

        }
    }
}