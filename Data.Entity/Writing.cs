using Base.Abstractions;
using System;


namespace Data.Entity
{
    public class Writing : BaseEntity
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Content { get; set; }
        public DateTime? Published { get; set; }
    }
}