using Base.Abstractions;


namespace Data.Entity
{
    public class Rating : BaseEntity
    {
        public int UserId { get; set; }
        public int WritingId { get; set; }
        public int Content { get; set; }
    }
}