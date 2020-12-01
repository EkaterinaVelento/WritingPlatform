using AutoMapper;
using Data.Entity;
using Models.Ratings;


namespace Service.Mapping.Profiles
{
    internal class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<Rating, RatingModel>();
            CreateMap<RatingModel, Rating>();
            CreateMap<NewRatingModel, Rating>();
        }
    }
}