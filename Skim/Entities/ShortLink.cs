using System;

namespace Skim.Entities
{
    public class ShortLink
    {
        public Guid Id { get; set; }
        public string FullLink { get; set; }
        public string Slug { get; set; }
    }
}