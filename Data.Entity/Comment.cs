using Base.Abstractions;


namespace Data.Entity
{
    public class Comment : BaseEntity
    {
        public int UserId { get; set; }
        public int WritingId { get; set; }
        public string Content { get; set; }
    }
}