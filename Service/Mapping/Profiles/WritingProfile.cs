using AutoMapper;
using Data.Entity;
using Models.Writings;


namespace Service.Mapping.Profiles
{
    internal class WritingProfile : Profile
    {
        public WritingProfile()
        {
            CreateMap<Writing, WritingModel>();
            CreateMap<WritingModel, Writing>();
            CreateMap<NewWritingModel, Writing>();
        }
    }
}