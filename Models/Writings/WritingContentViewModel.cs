using System.Collections.Generic;

namespace Models.Writings
{
    public class WritingContentViewModel
    {
        public IEnumerable<char> Content { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}