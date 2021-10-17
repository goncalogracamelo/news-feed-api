using System.Collections.Generic;
using System.Threading.Tasks;
using NewsFeed.API.Application.Data.Gateways;
using NewsFeed.API.Application.Domain;

namespace NewsFeed.API.Application.Services
{
    public class NewsFeedService : INewsFeedService
    {
        private readonly INewsGateway _newsGateway;

        public NewsFeedService(INewsGateway newsGateway)
        {
            _newsGateway = newsGateway;
        }

        public async Task<IEnumerable<NewsFeedItem>> GetAllNewsFeed()
        {
            var feed1 = await _newsGateway.GetNewsFeed();

            var feedList = new List<NewsFeedItem>() { feed1 };

            return await Task.FromResult(feedList);
        }
    }
}
