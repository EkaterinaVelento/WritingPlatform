namespace Models.Comments
{
    public class NewCommentModel
    {
        public int UserId { get; set; }
        public int WritingId { get; set; }
        public string Content { get; set; }
    }
}