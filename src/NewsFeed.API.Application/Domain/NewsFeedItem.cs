using System.Collections.Generic;

namespace NewsFeed.API.Application.Domain
{
    public class NewsFeedItem
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public NewsFeedImage Img { get; set; }
        public IEnumerable<NewsFeedEntries> Entries { get; set; }
    }
}
