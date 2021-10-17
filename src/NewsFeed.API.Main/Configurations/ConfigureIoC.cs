
using Microsoft.Extensions.DependencyInjection;
using NewsFeed.API.Application.Services;

namespace NewsFeed.API.Main.Configurations
{
    public static class ConfigureIoC
    {
        public static IServiceCollection ConfigureIoc(this IServiceCollection services)
        {
            services.AddTransient<INewsFeedService, NewsFeedService>();
            return services;
        }
    }
}
