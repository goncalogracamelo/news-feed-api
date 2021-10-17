using NewsFeed.API.Application.Domain;
using System.Threading.Tasks;

namespace NewsFeed.API.Application.Data.Gateways
{
    public interface INewsGateway
    {
        Task<NewsFeedItem> GetNewsFeed();
    }
}