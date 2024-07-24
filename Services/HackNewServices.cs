using System.Globalization;
using WebApplicationHacker.Class;
using WebApplicationHacker.Dto;
using WebApplicationHacker.Interface;

namespace WebApplicationHacker.Services
{
    public class HackNewServices : IHackNewServices
    {
        public Task<HackResultDto> HackNewResponse(HackNewResponse? objectData)
        {
            var totalCount = 0;
            totalCount = objectData.Kids.Count();
            DateTime timeNews = DateTimeOffset.FromUnixTimeSeconds(objectData.Time).DateTime;

            var result = new HackResultDto
            {
                By = objectData.By,
                Descendants = objectData.Descendants,
                Id = objectData.Id,
                CommentCount = totalCount,
                Score = objectData.Score,
                Time = timeNews,
                Title = objectData.Title,
                Type = objectData.Type,
                Url = objectData.Url
            };

            return Task.FromResult(result);
        }
    }
}
