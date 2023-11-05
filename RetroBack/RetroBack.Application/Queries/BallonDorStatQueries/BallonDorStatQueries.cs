using Microsoft.AspNetCore.Mvc;
using RetroBack.Application.Common;
using RetroBack.Application.QueryProjections;

namespace RetroBack.Application.Queries.BallonDorStatQueries
{
    public class GetBallonDorStatQuery : BaseRequest<CommandResponse<BallonDorStatListItemDto>>
    {
        public Guid StatId { get; set; }
    }

    public class GetBallonDorStatsQuery : BaseRequest<CommandResponse<List<BallonDorStatListItemDto>>>
    {
        [FromQuery]
        public string? Nickname { get; set; }
    }
}
