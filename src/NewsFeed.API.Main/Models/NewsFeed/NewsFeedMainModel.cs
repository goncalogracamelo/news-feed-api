using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeed.API.Main.Models.NewsFeed
{
    public class NewsFeedMainModel
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public NewsFeedImageModel Img { get; set; }
        public IEnumerable<NewsFeedEntriesModel> Entries { get; set; }
    }
}
