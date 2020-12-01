using System.Collections.Generic;


namespace Models.Writings
{
    public class WritingsViewModel
    {
        public IEnumerable<WritingModel> Writings { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}