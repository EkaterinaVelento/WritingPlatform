using System;


namespace Models.Writings
{
    public class WritingPublishingModel : IdentityModel
    {
        public DateTime? Published { get; set; }
    }
}