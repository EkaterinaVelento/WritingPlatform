using AutoMapper;
using Data.Entity;
using Models.Users;


namespace Service.Mapping.Profiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<NewUserModel, User>();
        }
    }
}