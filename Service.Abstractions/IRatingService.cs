using Models.Ratings;
using System.Collections.Generic;


namespace Service.Abstractions
{
    public interface IRatingService
    {
        void Create(NewRatingModel model);
        RatingModel GetById(int id);
        IEnumerable<RatingModel> GetAllByWritingId(int id);
        void Update(RatingModel model);
        void DeleteById(int id);
        void DeleteAllByWritingId(int id);
    }
}