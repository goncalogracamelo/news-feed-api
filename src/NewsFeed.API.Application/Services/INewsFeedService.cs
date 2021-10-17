using NewsFeed.API.Application.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsFeed.API.Application.Services
{
    public interface INewsFeedService
    {
        Task<IEnumerable<NewsFeedItem>> GetAllNewsFeed();
    }
}