using System;
using System.Collections.Generic;

namespace NewsFeed.API.Application.Domain
{
    public class NewsFeedEntries
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public DateTime? PubDate { get; set; }
        public IEnumerable<string> Authors { get; set; }
    }
}