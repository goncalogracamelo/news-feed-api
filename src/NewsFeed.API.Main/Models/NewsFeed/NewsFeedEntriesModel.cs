using System;
using System.Collections.Generic;

namespace NewsFeed.API.Main.Models.NewsFeed
{
    public class NewsFeedEntriesModel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string PubDate { get; set; }
        public IEnumerable<string> Authors { get; set; }
    }
}