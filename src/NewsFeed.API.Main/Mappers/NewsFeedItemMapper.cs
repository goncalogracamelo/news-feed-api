using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeed.API.Main.Mappers
{
    //TODO: break this per classes (SRP or add AutoMapper)
    public static class NewsFeedItemMapper
    {
        public static IEnumerable<Models.NewsFeed.NewsFeedMainModel> ToModel(this IEnumerable<Application.Domain.NewsFeedItem> @this) =>
            @this.Select(x => x.ToModel());

        public static Models.NewsFeed.NewsFeedMainModel ToModel(this Application.Domain.NewsFeedItem @this) =>
            new Models.NewsFeed.NewsFeedMainModel
            {
                Title = @this.Title,
                Desc = @this.Desc,
                Img = @this?.Img.ToModel(),
                Entries = @this?.Entries.ToModel()
            };

        public static Models.NewsFeed.NewsFeedImageModel ToModel(this Application.Domain.NewsFeedImage @this) =>
            new Models.NewsFeed.NewsFeedImageModel
            {
                Url = @this.Url,
                Title = @this.Title
            };

        public static IEnumerable<Models.NewsFeed.NewsFeedEntriesModel> ToModel(this IEnumerable<Application.Domain.NewsFeedEntries> @this) =>
            @this.Select(x => x.ToModel());

        public static Models.NewsFeed.NewsFeedEntriesModel ToModel(this Application.Domain.NewsFeedEntries @this) =>
            new Models.NewsFeed.NewsFeedEntriesModel
            {
                Title = @this.Title,
                Link = @this.Link,
                //PubDate = @this.PubDate
                PubDate = ConvertTimeForZone(@this.PubDate, "E. Europe Standard Time"),
                Authors = @this.Authors
            };

        private static string ConvertTimeForZone(DateTime? dt, string zoneName) //, TimeZoneInfo destinationTimeZone)
        {
            if (!dt.HasValue)
            {
                return null;
            }

            try
            {
                //The conversion could not be completed because the supplied DateTime did not have the Kind property set correctly.  For example, when the Kind property is DateTimeKind.Local, the source time zone must be TimeZoneInfo.Local. (Parameter 'sourceTimeZone')
                TimeZoneInfo zoneInfo = TimeZoneInfo.FindSystemTimeZoneById(zoneName);

                DateTime convertedDt = TimeZoneInfo.ConvertTimeFromUtc(dt.Value.ToUniversalTime(), zoneInfo);

                return convertedDt.ToString("dd-MM-yyyy HH:mm:ss");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
