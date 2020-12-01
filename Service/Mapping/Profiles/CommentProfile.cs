using AutoMapper;
using Data.Entity;
using Models.Comments;


namespace Service.Mapping.Profiles
{
    internal class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentModel>();
            CreateMap<CommentModel, Comment>();
            CreateMap<NewCommentModel, Comment>();
        }
    }
}