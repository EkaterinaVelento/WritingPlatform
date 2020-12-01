using AutoMapper.Configuration;
using Service.Mapping.Profiles;


namespace Service.Mapping
{
    internal class MapperExpression : MapperConfigurationExpression
    {
        public MapperExpression()
        {
            AddProfile<UserProfile>();
            AddProfile<WritingProfile>();
            AddProfile<CommentProfile>();
            AddProfile<RatingProfile>();
        }
    }
}