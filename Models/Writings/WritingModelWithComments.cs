using Models.Comments;
using System.Collections.Generic;


namespace Models.Writings
{
    public class WritingModelWithComments : WritingModel
    {
        public double Rating { get; set; }
        public IEnumerable<CommentModel> Comments { get; set; }

        public WritingModelWithComments(
            WritingModel writing, 
            double rating, 
            IEnumerable<CommentModel> comments)
        {
            Id = writing.Id;
            UserId = writing.UserId;
            Title = writing.Title;
            Genre = writing.Genre;
            Content = writing.Content;
            Rating = rating;
            Comments = comments;
        }
    }
}