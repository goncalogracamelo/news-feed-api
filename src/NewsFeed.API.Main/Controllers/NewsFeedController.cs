using Microsoft.AspNetCore.Mvc;
using NewsFeed.API.Application.Services;
using NewsFeed.API.Main.Mappers;
using System.Threading.Tasks;

namespace NewsFeed.API.Main.Controllers
{
    [Route("newsfeed")]
    public class NewsFeedController : BaseController
    {
        private readonly INewsFeedService _newsFeedService;

        public NewsFeedController(INewsFeedService newsFeedService)
        {
            _newsFeedService = newsFeedService;
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetAllNewsFeeds()
        {
            var result = await _newsFeedService.GetAllNewsFeed();
          
            return (IActionResult) await Task.FromResult(Ok(result.ToModel()));
        }

        

    }    
}
