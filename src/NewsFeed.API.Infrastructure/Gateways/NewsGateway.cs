using NewsFeed.API.Application.Data.Gateways;
using NewsFeed.API.Application.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NewsFeed.API.Infrastructure.Gateways
{
    public class NewsGateway : INewsGateway
    {

        private HttpClient _client;

        public NewsGateway(HttpClient client)
        {
            _client = client;
            //http://rss.cnn.com/rss/edition.rss
            _client.BaseAddress = new Uri("http://rss.cnn.com"); 
            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.DefaultRequestHeaders.Clear();
        }

        public async Task<NewsFeedItem> GetNewsFeed()
        {
            return await GetNewFeed(new CancellationToken());
        }

        private async Task<NewsFeedItem> GetNewFeed(CancellationToken cancellationToken)
        {            
            using (var response = await _client.GetAsync("/rss/edition.rss", cancellationToken))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                //using XElement is safe from XXE
                XElement doc = XElement.Load(stream, LoadOptions.None);
                return await LoadNewsFeedItemFromXElement(doc);
            }
        }

        private async Task<NewsFeedItem> LoadNewsFeedItemFromXElement(XElement doc)
        {
            var feed = new NewsFeedItem();

            XElement channelElem = doc.Element("channel");
            feed.Title = channelElem.Element("title").Value;
            feed.Desc = channelElem.Element("description").Value;

            XElement imageElem = channelElem.Element("image");
            feed.Img = new NewsFeedImage()
            {
                Title = imageElem.Element("title").Value,
                Url = imageElem.Element("url").Value
            };
            var feedEntries = new List<NewsFeedEntries>();

            foreach (var item in channelElem.Elements("item"))
            {
                var entry = GetFeedEntryFromXmlItem(item);
                if (entry != null)
                {
                    feedEntries.Add(entry);
                }                
            }
            feed.Entries = feedEntries;

            return await Task.FromResult(feed);
        }

        private NewsFeedEntries GetFeedEntryFromXmlItem(XElement item)
        {
            NewsFeedEntries entry = new NewsFeedEntries();

            entry.Title = item.Element("title")?.Value;
            if (string.IsNullOrEmpty(entry.Title))
            {
                return null;
            }

            entry.Link = item.Element("link")?.Value;
            
            var pubDateText = item.Element("pubDate")?.Value;
            entry.PubDate = (string.IsNullOrWhiteSpace(pubDateText)) ? null : DateTime.Parse(pubDateText);

            return entry;
        }
    }
}
